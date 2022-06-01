using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clue : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] List<DialoguePhrase> myDialogue;
    [SerializeField] Sprite mySprite;

    DialogueSystem dialogueSystem;
    DialogueText dialogueText;
    CharacterObject myCharacter;

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
        myCharacter.dialogue = myDialogue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("работает?");
        dialogueSystem.SetNewDialogue(myCharacter);
        dialogueText.EnableText();
    }
}
