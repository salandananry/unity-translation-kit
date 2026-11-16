
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class TranslationData
{
    public Dictionary<string, Dictionary<string, string>> translations;
}

[Serializable]
public class SelectedLanguageData
{
    public string selectedLanguage;
}

public class LanguageDatabase
{
    private static LanguageDatabase _instance;

    public static LanguageDatabase Instance
    {
        get
        {
            if (_instance == null)
                _instance = new LanguageDatabase();

            return _instance;
        }
    }

    private Dictionary<string, Dictionary<string, string>> _translations;

    public string SelectedLanguage { get; set; } = "english";

    public bool IsInitialized { get; private set; }

    public static event Action OnInitalized;

    private LanguageDatabase()
    {
        LoadSelectedLanguage();
    }
    [RuntimeInitializeOnLoadMethod(
    RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeOnRuntimeStart()
    {
        TextAsset translationFile =
            Resources.Load<TextAsset>("translations");

        if (translationFile == null)
        {
            Debug.LogError(
                "Could not find translations.json in a Resources folder."
            );
            return;
        }

        Instance.Initialize(translationFile.text);
    }
    public void Initialize(string json)
    {
        try
        {
            TranslationData data =
                JsonConvert.DeserializeObject<TranslationData>(json);

            if (data?.translations == null)
            {
                Debug.LogError("Failed to parse translation file.");
                return;
            }

            Initialize(data.translations);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to initialize LanguageDatabase:\n{e}");
        }
    }

    public void Initialize(
        Dictionary<string, Dictionary<string, string>> translations)
    {
        if (translations == null)
        {
            Debug.LogError("Cannot initialize with null translations.");
            return;
        }

        _translations = translations;
        IsInitialized = true;

        OnInitalized?.Invoke();

        Debug.Log("LanguageDatabase initialized.");
    }

    public string GetTranslation(string key, string fallback)
    {
        if (_translations == null)
            return fallback;

        if (!_translations.TryGetValue(key, out var languageTranslations))
            return fallback;

        if (languageTranslations.TryGetValue(
            SelectedLanguage,
            out string translation))
        {
            return translation;
        }

        return fallback;
    }

    private void LoadSelectedLanguage()
    {
        string path = Path.Combine(
            Application.persistentDataPath,
            "selectedLanguage.json"
        );

        if (!File.Exists(path))
            return;

        try
        {
            string json = File.ReadAllText(path);

            SelectedLanguageData data =
                JsonConvert.DeserializeObject<SelectedLanguageData>(json);

            if (data != null)
                SelectedLanguage = data.selectedLanguage ?? "english";
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load selected language:\n{e}");
        }
    }

    public void SaveSelectedLanguage()
    {
        try
        {
            SelectedLanguageData data = new SelectedLanguageData
            {
                selectedLanguage = SelectedLanguage
            };

            string path = Path.Combine(
                Application.persistentDataPath,
                "selectedLanguage.json"
            );

            string json = JsonConvert.SerializeObject(
                data,
                Formatting.Indented
            );

            File.WriteAllText(path, json);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save selected language:\n{e}");
        }
    }
}
