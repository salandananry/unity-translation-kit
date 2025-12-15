using System;
using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    public static event Action OnLanguageChanged;

    public void ChangeLanguage(string selectedLangauge)
    {
        LanguageDatabase.Instance._selectedLanguage = selectedLangauge;
        LanguageDatabase.Instance.SaveTranslationData();
        OnLanguageChanged?.Invoke();
    }
}