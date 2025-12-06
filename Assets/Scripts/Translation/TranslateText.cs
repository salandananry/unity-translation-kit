using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TranslateText : MonoBehaviour
{
    [SerializeField] private string translationKey;
    
    [TextArea(3,15)]
    [SerializeField] private string fallback;
    
    private TextMeshProUGUI displayText;
    private void Awake()
    {
        displayText = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        Translate();
        LanguageSelector.OnLanguageChanged += Translate;
    }
    private void OnDisable()
    {
        LanguageSelector.OnLanguageChanged -= Translate;
    }
    private void Translate()
    {
        displayText.text = LanguageDatabase.Instance.GetTranslation(translationKey, fallback);
        DebugHandler.Log($"TEXT TRANSLATED [{LanguageDatabase.Instance._selectedLanguage}]");
    }
}