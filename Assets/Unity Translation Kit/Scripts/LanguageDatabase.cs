using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using System;

[System.Serializable]
public class LanguageFileData
{
    public string selectedLanguage;
    public Dictionary<string, Dictionary<string, string>> translations;
}

public class LanguageDatabase : MonoBehaviour
{
    public static event Action OnInitalized;
    public static LanguageDatabase Instance { get; private set; }

    [SerializeField] private string apiKey;
    [SerializeField] private string spreadSheetID;
    [SerializeField] private string fileName = "translations.json";

    public string _selectedLanguage = "en";

    private Dictionary<string, Dictionary<string, string>> _translations;
    public bool IsInitialized { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private async void Start()
    {
        LoadSelectedLanguage();

        bool HasConnection = await ConnectionStatus.HasConnection();
        if (HasConnection)
        {
            await UpdateTranslationFile();
        }
        else
        {
            LoadTranslationFile();
        }
        IsInitialized = true;
        OnInitalized?.Invoke();
    }
    private async Task UpdateTranslationFile()
    {
        _translations = await TranslationSheet.FetchAllSheets(apiKey, spreadSheetID);

        if (_translations == null)
        {
            DebugHandler.Warning("Failed to download spreadsheet data. Using cached file.");
            LoadTranslationFile();
            return;
        }
        DebugHandler.Log("Translation successfully fetched.");
        NormalizeTranslations();
        SaveTranslationData();
    }
    private void LoadSelectedLanguage()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (!File.Exists(path)) return;

        string json = File.ReadAllText(path);
        var data = JsonConvert.DeserializeObject<LanguageFileData>(json);

        if (data == null) return;

        _selectedLanguage = data.selectedLanguage ?? "en";
        DebugHandler.Log("Loaded selected language from local file.");

    }
    private void LoadTranslationFile()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);

        if (!File.Exists(path)) return;

        string json = File.ReadAllText(path);

        var data = JsonConvert.DeserializeObject<LanguageFileData>(json);

        if (data == null || data.translations == null) return;

        _translations = data.translations;

        DebugHandler.Log("Loaded translations from local file.");
    }
    private void NormalizeTranslations()
    {
        foreach (var entry in _translations)
        {
            var languages = new List<string>(entry.Value.Keys);

            foreach (var lang in languages)
            {
                if (string.IsNullOrWhiteSpace(entry.Value[lang]))
                    entry.Value.Remove(lang);
            }
        }
    }
    public void SaveTranslationData()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);

        var data = new LanguageFileData
        {
            selectedLanguage = _selectedLanguage,
            translations = _translations
        };

        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(path, json);
        DebugHandler.Log("Selected Language and Translations saved successfully.");
    }
    public string GetTranslation(string key, string fallback)
    {
        if (_translations == null)
            return fallback;

        if (!_translations.ContainsKey(key))
            return fallback;

        if (_translations[key].ContainsKey(_selectedLanguage))
            return _translations[key][_selectedLanguage];

        return fallback;
    }
}