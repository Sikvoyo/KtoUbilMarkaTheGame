using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueText : MonoBehaviour
{
    [SerializeField] bool onAwake;

    GameObject contents;
    DialogueSystem dialogueSystem;

    private void Awake() 
    {
        contents = GameObject.Find("Contents");
        if (!onAwake)
            DisableText();

        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    public void EnableText()
    {
        contents.SetActive(true);
    }

    public void DisableText()
    {
        contents.SetActive(false);
    }

    public void OnDisappearAnimation()
    {
        if (!dialogueSystem.IsTalking)
        {
            DisableText();
        }
    }
}
