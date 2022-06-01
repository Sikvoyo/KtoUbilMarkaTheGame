using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueText : MonoBehaviour
{
    [SerializeField] bool onAwake;

    GameObject contents;

    private void Awake() 
    {
        contents = GameObject.Find("Contents");
        if (!onAwake)
            DisableText();
    }

    public void EnableText()
    {
        contents.SetActive(true);
    }

    public void DisableText()
    {
        contents.SetActive(false);
    }
}
