using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TranslateText : MonoBehaviour
{
    [Tooltip("A unique identifier used to retrieve the appropriate translation.")]
    [SerializeField] private string translationKey;

    [Tooltip("Displayed when the translation key is missing or no translation exists for the selected language.")]
    [TextArea(3, 15)]
    [SerializeField] private string fallback;

    private TextMeshProUGUI displayText;
    private void Awake()
    {
        displayText = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        if (LanguageDatabase.Instance != null && LanguageDatabase.Instance.IsInitialized)
        {
            Translate();
        }
        else
        {
            LanguageDatabase.OnInitalized += Translate;
        }
        LanguageSelector.OnLanguageChanged += Translate;
    }
    private void OnDisable()
    {
        LanguageDatabase.OnInitalized -= Translate;
        LanguageSelector.OnLanguageChanged -= Translate;
    }
    private void Translate()
    {
        if (LanguageDatabase.Instance == null || !LanguageDatabase.Instance.IsInitialized) return;
        displayText.text = LanguageDatabase.Instance.GetTranslation(translationKey, fallback);
    }
}