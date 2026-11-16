using System;
using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    public static event Action OnLanguageChanged;

    public void ChangeLanguage(string selectedLangauge)
    {
        LanguageDatabase.Instance.SelectedLanguage = selectedLangauge;
        //LanguageDatabase.Instance.SaveTranslationData();
        LanguageDatabase.Instance.SaveSelectedLanguage();
        OnLanguageChanged?.Invoke();
    }
}