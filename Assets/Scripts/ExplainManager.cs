using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplainManager : MonoBehaviour
{
    [SerializeField] CharacterObject mayor;

    DialogueSystem dialogueSystem;

    private void Start() 
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        dialogueSystem.SetNewDialogue(mayor);
        dialogueSystem.OnLastPhrase += LoadDomScene;
    }

    private void LoadDomScene()
    {
        SceneManager.LoadScene("Dom");
        dialogueSystem.OnLastPhrase -= LoadDomScene;
    }
}
