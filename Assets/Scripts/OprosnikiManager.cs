using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OprosnikiManager : MonoBehaviour
{
    [SerializeField] Image dialogueSprite;

    private CharacterObject characterSpeaking;
    
    DialogueSystem dialogueSystem;

    private void Start() 
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    public void ChangeCharacter(CharacterObject newCharacter)
    {
        if (newCharacter == characterSpeaking) return;

        characterSpeaking = newCharacter;

        dialogueSprite.sprite = characterSpeaking.characterSprite;
        dialogueSystem.SetNewDialogue(newCharacter);
    }

    public CharacterObject WhoSpeaks()
    {
        return characterSpeaking;
    }
}
