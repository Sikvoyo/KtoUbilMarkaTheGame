using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class ExplainManager : MonoBehaviour
{
    [SerializeField] CharacterObject mayorRU;
    [SerializeField] CharacterObject mayorEN;

    DialogueSystem dialogueSystem;

    private void Start() 
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        dialogueSystem.SetNewDialogue(
            LocalizationSettings.SelectedLocale.name == "English (en)" ? mayorEN : mayorRU
        );
        dialogueSystem.OnLastPhrase += LoadDomScene;
    }

    private void LoadDomScene()
    {
        SceneManager.LoadScene("Dom");
        dialogueSystem.OnLastPhrase -= LoadDomScene;
    }
}
