using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Animator animator;
    [SerializeField] HandDrawnEllipse handDrawnEllipse;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        animator.SetBool("hovered", true);
        if (handDrawnEllipse)
        {
            handDrawnEllipse.SetHDEActivate(true);
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        animator.SetBool("hovered", false);
        if (handDrawnEllipse)
        {
            handDrawnEllipse.SetHDEActivate(false);
        }
    }
}
