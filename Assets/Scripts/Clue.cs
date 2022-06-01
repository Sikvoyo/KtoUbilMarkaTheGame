using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
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

    private void OnMouseDown() 
    {
        Debug.Log(dialogueText == null);
        dialogueSystem.SetNewDialogue(myCharacter);
        dialogueText.EnableText();
    }
}
