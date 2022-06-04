using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageButton : MonoBehaviour
{
    [SerializeField] string language;

    public void ChangeLanguage()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales
        [
            language == "en" ? 0 : 1
        ];
    }
}
