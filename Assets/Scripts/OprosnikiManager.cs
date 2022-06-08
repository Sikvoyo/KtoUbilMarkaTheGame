using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OprosnikiManager : MonoBehaviour
{
    [SerializeField] Image dialogueSprite;
    [SerializeField] Animator animator;

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
        dialogueSystem.SetNewDialogue(characterSpeaking);
    }

    public CharacterObject WhoSpeaks()
    {
        return characterSpeaking;
    }
}
