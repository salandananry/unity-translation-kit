
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Networking;

public static class TranslationSheet
{
    public static string LastError { get; private set; }

    public static async Task<
        Dictionary<string, Dictionary<string, string>>
    > FetchAllSheets(
        string apiKey,
        string spreadsheetId
    )
    {
        LastError = null;

        TranslationEditorWindow.AddStatusMessage(
            "Connecting to Google Sheets..."
        );

        string metaUrl =
            $"https://sheets.googleapis.com/v4/spreadsheets/" +
            $"{spreadsheetId}?key={apiKey}";

        string metaJson = await GetRequest(metaUrl);

        if (metaJson == null)
        {
            return null;
        }

        JObject meta;

        try
        {
            meta = JObject.Parse(metaJson);
        }
        catch (Exception e)
        {
            ReportError(
                $"Failed to parse spreadsheet metadata: {e.Message}"
            );

            return null;
        }

        JArray sheets = meta["sheets"] as JArray;

        if (sheets == null)
        {
            ReportError(
                "The Google Sheets response contains no sheets."
            );

            return null;
        }

        var flatResult =
            new Dictionary<
                string,
                Dictionary<string, string>
            >();

        TranslationEditorWindow.AddStatusMessage(
            $"Found {sheets.Count} sheet(s). Starting download..."
        );

        foreach (var sheet in sheets)
        {
            string sheetName =
                sheet["properties"]?["title"]?.ToString();

            if (string.IsNullOrWhiteSpace(sheetName))
            {
                ReportError("A sheet has no valid name.");
                return null;
            }

            TranslationEditorWindow.AddStatusMessage(
                $"Downloading sheet: {sheetName}"
            );

            string encodedSheetName =
                Uri.EscapeDataString(sheetName);

            string sheetUrl =
                $"https://sheets.googleapis.com/v4/" +
                $"spreadsheets/{spreadsheetId}/values/" +
                $"{encodedSheetName}?key={apiKey}";

            string sheetDataJson =
                await GetRequest(sheetUrl);

            if (sheetDataJson == null)
            {
                TranslationEditorWindow.AddStatusMessage(
                    $"Download cancelled for sheet '{sheetName}'."
                );
                return null;
            }

            var parsedSheet = ParseSheet(sheetDataJson);

            if (parsedSheet == null)
            {
                ReportError(
                    $"Failed to process sheet '{sheetName}'. " +
                    $"{LastError ?? "Unknown parsing error."}",
                    false
                );

                return null;
            }

            foreach (var kv in parsedSheet)
            {
                flatResult[kv.Key] = kv.Value;
            }

            TranslationEditorWindow.AddStatusMessage(
                $"Successfully processed sheet: {sheetName} " +
                $"({parsedSheet.Count} translation key(s))."
            );
        }

        TranslationEditorWindow.AddStatusMessage(
            $"All sheets downloaded successfully. " +
            $"Total translation keys: {flatResult.Count}."
        );

        return flatResult;
    }

    private static Dictionary<
        string,
        Dictionary<string, string>
    > ParseSheet(string json)
    {
        JObject sheetObj;

        try
        {
            sheetObj = JObject.Parse(json);
        }
        catch (Exception e)
        {
            LastError = $"Invalid sheet data: {e.Message}";
            return null;
        }

        JArray values = sheetObj["values"] as JArray;

        // Empty sheets are allowed.
        if (values == null || values.Count < 2)
        {
            return new Dictionary<
                string,
                Dictionary<string, string>
            >();
        }

        JArray header = values[0] as JArray;

        if (header == null)
        {
            LastError = "The sheet has no valid header row.";
            return null;
        }

        var result =
            new Dictionary<
                string,
                Dictionary<string, string>
            >();

        for (
            int rowIndex = 1;
            rowIndex < values.Count;
            rowIndex++
        )
        {
            JArray row = values[rowIndex] as JArray;

            if (row == null || row.Count == 0)
            {
                continue;
            }

            string key = row[0]?.ToString();

            if (string.IsNullOrWhiteSpace(key))
            {
                continue;
            }

            var translations =
                new Dictionary<string, string>();

            for (
                int col = 1;
                col < header.Count;
                col++
            )
            {
                string language = header[col]?.ToString();

                if (string.IsNullOrWhiteSpace(language))
                {
                    continue;
                }

                string text =
                    col < row.Count
                        ? row[col]?.ToString() ?? ""
                        : "";

                translations[language] = text;
            }

            result[key] = translations;
        }

        return result;
    }

    private static async Task<string> GetRequest(string url)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.timeout = 5;

            var operation = request.SendWebRequest();

            while (!operation.isDone)
            {
                await Task.Yield();
            }

            if (request.result == UnityWebRequest.Result.Success)
            {
                return request.downloadHandler.text;
            }

            string details = request.error;
            long responseCode = request.responseCode;

            string responseBody = request.downloadHandler?.text;

            if (!string.IsNullOrWhiteSpace(responseBody))
            {
                try
                {
                    JObject errorJson = JObject.Parse(responseBody);

                    string apiMessage =
                        errorJson["error"]?["message"]?.ToString();

                    if (!string.IsNullOrWhiteSpace(apiMessage))
                    {
                        details = apiMessage;
                    }
                }
                catch
                {
                }
            }

            string reason = responseCode switch
            {
                400 => "Invalid request. Check the spreadsheet ID or request.",
                401 => "Authentication failed. Check your API key.",
                403 => "Access denied. Check API key permissions and Google Sheets API settings.",
                404 => "Spreadsheet or requested resource not found.",
                429 => "Google API rate limit exceeded. Try again later.",
                _ => details ?? "Unknown network or request error."
            };

            LastError = responseCode > 0
                ? $"HTTP {responseCode}: {reason}"
                : $"Request failed: {reason}";

            TranslationEditorWindow.AddStatusMessage(
                $"Request failed: {LastError}"
            );

            return null;
        }
    }

    private static void ReportError(
        string message,
        bool updateLastError = true
    )
    {
        if (updateLastError)
        {
            LastError = message;
        }

        TranslationEditorWindow.AddStatusMessage(message);
    }
}
