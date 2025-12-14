using Newtonsoft.Json.Linq; //com.unity.nuget.newtonsoft-json//
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class TranslationSheet
{
    public static async Task<Dictionary<string, Dictionary<string, string>>> FetchAllSheets(string apiKey, string spreadsheetId)
    {
        string metaUrl = $"https://sheets.googleapis.com/v4/spreadsheets/{spreadsheetId}?key={apiKey}";

        string metaJson = await GetRequest(metaUrl);
        if (metaJson == null)
            return null;

        JObject meta = JObject.Parse(metaJson);
        JArray sheets = (JArray)meta["sheets"];

        var flatResult = new Dictionary<string, Dictionary<string, string>>();

        foreach (var sheet in sheets)
        {
            string sheetName = sheet["properties"]["title"].ToString();

            string sheetUrl = $"https://sheets.googleapis.com/v4/spreadsheets/{spreadsheetId}/values/{sheetName}?key={apiKey}";

            string sheetDataJson = await GetRequest(sheetUrl);
            if (sheetDataJson == null)
                continue;

            var parsedSheet = ParseSheet(sheetDataJson);

            if (parsedSheet != null)
            {
                foreach (var kv in parsedSheet)
                {
                    flatResult[kv.Key] = kv.Value;
                }
            }
        }

        return flatResult;
    }

    private static Dictionary<string, Dictionary<string, string>> ParseSheet(string json)
    {
        JObject sheetObj = JObject.Parse(json);
        JArray values = (JArray)sheetObj["values"];

        if (values == null || values.Count < 2)
            return null;

        var result = new Dictionary<string, Dictionary<string, string>>();

        JArray header = (JArray)values[0];

        for (int rowIndex = 1; rowIndex < values.Count; rowIndex++)
        {
            JArray row = (JArray)values[rowIndex];

            string key = row[0]?.ToString();
            if (string.IsNullOrWhiteSpace(key))
                continue;

            var translations = new Dictionary<string, string>();

            for (int col = 1; col < row.Count; col++)
            {
                string lang = header[col]?.ToString();
                string text = row[col]?.ToString() ?? "";

                translations[lang] = text;
            }

            result[key] = translations;
        }

        return result;
    }
    private static async Task<string> GetRequest(string url)
    {
        using (UnityWebRequest req = UnityWebRequest.Get(url))
        {
            req.timeout = 5;
            var op = req.SendWebRequest();

            while (!op.isDone)
                await Task.Yield();

            if (req.result == UnityWebRequest.Result.Success)
                return req.downloadHandler.text;

            return null;
        }
    }
}