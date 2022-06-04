using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization.Settings;

public class Clue : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] List<DialoguePhrase> myDialogueRU;
    [SerializeField] List<DialoguePhrase> myDialogueEN;
    [SerializeField] Sprite mySprite;

    DialogueSystem dialogueSystem;
    DialogueText dialogueText;
    CharacterObject myCharacter;

    // bool hovered = false;
    bool isTalking = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        dialogueText = FindObjectOfType<DialogueText>();
        CreateCharacterObject();
    }

    private void CreateCharacterObject()
    {
        myCharacter = CharacterObject.CreateInstance<CharacterObject>();
        myCharacter.characterName = gameObject.name;
        myCharacter.characterSprite = mySprite;
        myCharacter.dialogue = LocalizationSettings.SelectedLocale.name == "English (en)" ? myDialogueEN : myDialogueRU;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (isTalking) return;

        isTalking = true;
        dialogueSystem.SetNewDialogue(myCharacter);
        dialogueText.EnableText();
        dialogueSystem.OnLastPhrase += StopTalking;
    }

    private void StopTalking()
    {
        isTalking = false;
        dialogueSystem.OnLastPhrase -= StopTalking;
    }

    // public void OnPointerEnter(PointerEventData pointerEventData)
    // {
    //     hovered = true;
    // }

    // public void OnPointerExit(PointerEventData pointerEventData)
    // {
    //     hovered = false;
    // }
}
