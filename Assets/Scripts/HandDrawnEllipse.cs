using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDrawnEllipse : MonoBehaviour
{
    public event Action OnFinishedClick;

    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip pencilCircle;
    [SerializeField] AudioClip pencilClick;

    public void SetHDEActivate(bool state)
    {
        animator.SetBool("activate", state);
        if (state)
        {
            audioSource.PlayOneShot(pencilCircle);
        }
    }

    public void OnClick()
    {
        animator.SetTrigger("click");
        audioSource.PlayOneShot(pencilClick);
    }

    public void FinishClick()
    {
        OnFinishedClick?.Invoke();
    }
}
