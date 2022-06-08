using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoiceButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isEnabled = false;

    [SerializeField] Animator animator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isEnabled)
            animator.SetTrigger("entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isEnabled)
            animator.SetTrigger("exited");
    }
}
