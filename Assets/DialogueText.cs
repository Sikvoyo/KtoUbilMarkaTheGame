using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueText : MonoBehaviour
{
    public void EnableText()
    {
        gameObject.SetActive(true);
    }

    public void DisableText()
    {
        gameObject.SetActive(false);
    }
}
