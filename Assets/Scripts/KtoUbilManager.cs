using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Localization.Settings;

public class KtoUbilManager : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] Transform panelObject;
    [SerializeField] GameObject optionsObject;
    [SerializeField] GameObject endScreen;

    [Space(10)]

    [SerializeField] CharacterObject monokuma;

    [Space(5)]

    [SerializeField] CharacterObject monokumaDialoguesRU;
    [SerializeField] CharacterObject monokumaDialoguesEN;
    [SerializeField] CharacterObject otherDialoguesRU;
    [SerializeField] CharacterObject otherDialoguesEN;
    [SerializeField] Sprite mayorSprite;
    [SerializeField] Sprite win;
    [SerializeField] Sprite loss;


    DialogueSystem dialogueSystem;
    DialogueText dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += ShowOptions;
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        dialogueSystem.OnLastPhrase += HandleDialogueEnd;
        dialogueText = FindObjectOfType<DialogueText>();
    }

    private void ShowOptions(VideoPlayer source)
    {
        videoPlayer.loopPointReached -= ShowOptions;
        Destroy(panelObject.gameObject);
        optionsObject.SetActive(true);
    }

    public void OnOptionChosen(CharacterObject characterObject)
    {
        FindObjectOfType<DialogueText>().EnableText();
        optionsObject.SetActive(false);
        if (characterObject == monokuma)
        {
            dialogueSystem.SetNewDialogue(LocalizationSettings.SelectedLocale.name == "English (en)" ? monokumaDialoguesEN : monokumaDialoguesRU);
        }
        else
        {
            dialogueSystem.SetNewDialogue(LocalizationSettings.SelectedLocale.name == "English (en)" ? otherDialoguesEN : otherDialoguesRU);
        }
    }

     private void HandleDialogueEnd()
    {
        dialogueSystem.OnLastPhrase -= HandleDialogueEnd;
        endScreen.SetActive(true);
        dialogueText.EnableText();
        if (dialogueSystem.CurrentSpeaker == monokumaDialoguesRU || dialogueSystem.CurrentSpeaker == monokumaDialoguesEN)
        {
            endScreen.GetComponent<SpriteRenderer>().sprite = win;
        }
        else if (dialogueSystem.CurrentSpeaker == otherDialoguesRU || dialogueSystem.CurrentSpeaker == otherDialoguesEN)
        {
            endScreen.GetComponent<SpriteRenderer>().sprite = loss;
        }
        else
        {
            Debug.LogWarning("Чё-то не так");
        }
    }
}
