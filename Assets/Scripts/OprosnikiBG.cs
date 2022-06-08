using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OprosnikiBG : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] OprosnikiManager oprosnikiManager;

    public void ChangeImage()
    {
        image.sprite = oprosnikiManager.GetBackground();
    }
}
