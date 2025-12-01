using System;
using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    public static event Action OnLanguageChanged;

    public void ChangeLanguage(string selectedLangauge)
    {
        LanguageDataBase.Instance.selectedLanguage = selectedLangauge;
        OnLanguageChanged?.Invoke();
    }
}