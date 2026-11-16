
#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TranslationEditorWindow : EditorWindow
{
    private const string Version = "2.1.0";

    private string apiKey = "";
    private string spreadSheetID = "";
    private bool showApiKey;

    private readonly List<string> statusHistory = new List<string>();
    private Vector2 statusScrollPosition;

    [MenuItem("Tools/Salandananary/Unity Translation Kit/Translation Window")]
    private static void OpenWindow()
    {
        GetWindow<TranslationEditorWindow>("Translation Kit");
    }

    private void OnGUI()
    {
        GUILayout.Space(10);

        // Header
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();

        EditorGUILayout.LabelField(
            "Unity Translation Kit",
            EditorStyles.boldLabel
        );

        EditorGUILayout.LabelField(
            "developed by salandananry",
            EditorStyles.miniLabel
        );

        EditorGUILayout.EndVertical();

        GUILayout.FlexibleSpace();

        EditorGUILayout.LabelField(
            $"v{Version}",
            EditorStyles.miniLabel,
            GUILayout.Width(40)
        );

        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10);
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        GUILayout.Space(5);

        // Configuration
        EditorGUILayout.LabelField(
            "Configuration",
            EditorStyles.boldLabel
        );

        GUILayout.Space(5);

        EditorGUILayout.BeginHorizontal();

        apiKey = showApiKey
            ? EditorGUILayout.TextField("API Key", apiKey)
            : EditorGUILayout.PasswordField("API Key", apiKey);

        showApiKey = GUILayout.Toggle(
            showApiKey,
            showApiKey ? "Hide" : "Show",
            EditorStyles.miniButton,
            GUILayout.Width(45)
        );

        EditorGUILayout.EndHorizontal();

        spreadSheetID = EditorGUILayout.TextField(
            "Spreadsheet ID",
            spreadSheetID
        );

        GUILayout.Space(10);
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        GUILayout.Space(5);

        // Fetch Translations
        if (GUILayout.Button(
            "Fetch Translations",
            GUILayout.Height(35)
        ))
        {
            if (string.IsNullOrWhiteSpace(apiKey) ||
                string.IsNullOrWhiteSpace(spreadSheetID))
            {
                AddStatusMessage(
                    "Please enter both the API Key and Spreadsheet ID."
                );
            }
            else
            {
                AddStatusMessage("Fetching translations...");

                TranslationEditorUpdater.FetchTranslations(
                    apiKey.Trim(),
                    spreadSheetID.Trim()
                );
            }
        }

        GUILayout.Space(10);
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        GUILayout.Space(5);

        // Activity Log
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField(
            "Activity Log",
            EditorStyles.boldLabel
        );

        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Clear", GUILayout.Width(55)))
        {
            statusHistory.Clear();
        }

        EditorGUILayout.EndHorizontal();

        statusScrollPosition = EditorGUILayout.BeginScrollView(
            statusScrollPosition,
            GUILayout.ExpandHeight(true)
        );

        if (statusHistory.Count == 0)
        {
            EditorGUILayout.LabelField(
                "No activity yet.",
                EditorStyles.miniLabel
            );
        }
        else
        {
            foreach (string message in statusHistory)
            {
                EditorGUILayout.LabelField(
                    message,
                    EditorStyles.wordWrappedMiniLabel
                );
            }
        }

        EditorGUILayout.EndScrollView();

        GUILayout.Space(10);
    }

    public static void AddStatusMessage(string message)
    {
        TranslationEditorWindow window =
            GetWindow<TranslationEditorWindow>("Translation Kit");

        string timestamp = DateTime.Now.ToString("HH:mm:ss");

        window.statusHistory.Add($"[{timestamp}] {message}");
        window.statusScrollPosition.y = float.MaxValue;

        window.Repaint();
    }
}
#endif
