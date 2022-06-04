using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] CharacterObject myCharacterRU;
    [SerializeField] CharacterObject myCharacterEN;
    
    [Header("Компоненты")]
    [SerializeField] OprosnikiManager oprosnikiManager;

    public void OnButtonPressed()
    {
        Debug.Log("работает");
        oprosnikiManager.ChangeCharacter(LocalizationSettings.SelectedLocale.name == "English (en)" ? myCharacterEN : myCharacterRU);
    }
}
