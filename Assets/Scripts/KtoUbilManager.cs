using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class KtoUbilManager : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] Transform panelObject;
    [SerializeField] GameObject optionsObject;
    [SerializeField] GameObject dialogueTextObject;
    [SerializeField] GameObject endScreen;

    [Space(10)]

    [SerializeField] CharacterObject monokuma;

    [Space(5)]

    [SerializeField] CharacterObject monokumaDialogues;
    [SerializeField] CharacterObject otherDialogues;
    [SerializeField] Sprite mayorSprite;
    [SerializeField] Sprite win;
    [SerializeField] Sprite loss;


    DialogueSystem dialogueSystem;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += ShowOptions;
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        dialogueSystem.OnLastPhrase += HandleDialogueEnd;

    }

    private void ShowOptions(VideoPlayer source)
    {
        videoPlayer.loopPointReached -= ShowOptions;
        Destroy(panelObject.gameObject);
        optionsObject.SetActive(true);
    }

    public void OnOptionChosen(CharacterObject characterObject)
    {
        dialogueTextObject.SetActive(true);
        optionsObject.SetActive(false);
        if (characterObject == monokuma)
        {
            dialogueSystem.SetNewDialogue(monokumaDialogues);
        }
        else
        {
            dialogueSystem.SetNewDialogue(otherDialogues);
        }
    }

     private void HandleDialogueEnd()
    {
        dialogueSystem.OnLastPhrase -= HandleDialogueEnd;
        endScreen.SetActive(true);
        dialogueTextObject.SetActive(false);
        if (dialogueSystem.CurrentSpeaker == monokumaDialogues)
        {
            endScreen.GetComponent<SpriteRenderer>().sprite = win;
        }
        else if (dialogueSystem.CurrentSpeaker == otherDialogues)
        {
            endScreen.GetComponent<SpriteRenderer>().sprite = loss;
        }
        else
        {
            Debug.LogWarning("Чё-то не так");
        }
    }
}
