using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueText : MonoBehaviour
{
    [SerializeField] bool onAwake;

    GameObject content;

    private void Awake() 
    {
        content = GameObject.Find("Content");
        if (content == null)
            content = gameObject;
        if (!onAwake)
            DisableText();
    }

    public void EnableText()
    {
        content.SetActive(true);
    }

    public void DisableText()
    {
        content.SetActive(false);
    }
}
