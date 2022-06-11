using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization.Settings;

public class Clue : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] List<DialoguePhrase> myDialogueRU;
    [SerializeField] List<DialoguePhrase> myDialogueEN;
    [SerializeField] Sprite mySprite;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AudioClip hoverSound;
    [SerializeField] Color32 hoverColor;

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
        OnPointerExit(new PointerEventData(EventSystem.current));
        dialogueSystem.SetNewDialogue(myCharacter);
        dialogueText.EnableText();
        dialogueSystem.OnLastPhrase += StopTalking;
    }

    private void StopTalking()
    {
        isTalking = false;
        dialogueSystem.OnLastPhrase -= StopTalking;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isTalking) return;

        spriteRenderer.color = hoverColor;
        AudioSource.PlayClipAtPoint(hoverSound, Camera.main.transform.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        spriteRenderer.color = Color.white;
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
