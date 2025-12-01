using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class LanguageDataBase : MonoBehaviour
{
    public static LanguageDataBase Instance { get; private set; }

    [SerializeField] private string apiKey;
    [SerializeField] private string spreadSheetID;
    [SerializeField] private string fileName = "translations.json";
    public string selectedLanguage = "en";

    private Dictionary<string, Dictionary<string, string>> _translations;

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
        bool HasConnection = await ConnectionStatus.HasConnection();
        if (HasConnection)
        {
            await UpdateFile();
        }
        else
        {
            LoadLocalData();
        }
    }
    private async Task UpdateFile()
    {
        _translations = await TranslationSheet.FetchAllSheets(apiKey, spreadSheetID);

        if (_translations == null)
        {
            DebugHandler.Warning("Failed to download spreadsheet data. Using cached file.");
            LoadLocalData();
            return;
        }

        SaveLocalData();
        DebugHandler.Log("Translations downloaded and saved successfully.");
    }
    private void LoadLocalData()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (!File.Exists(path)) return;

        string json = File.ReadAllText(path);
        _translations = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);

        DebugHandler.Log("Loaded translations from local file.");
    }

    private void SaveLocalData()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        string json = JsonConvert.SerializeObject(_translations, Formatting.Indented);
        File.WriteAllText(path, json);
    }
    public string GetTranslation(string key, string fallback)
    {
        if (_translations == null || !_translations.ContainsKey(key)) return fallback;

        if (_translations[key].ContainsKey(selectedLanguage))
            return _translations[key][selectedLanguage];

        return fallback;
    }
}