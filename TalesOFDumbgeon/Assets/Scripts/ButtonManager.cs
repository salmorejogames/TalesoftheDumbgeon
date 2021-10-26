using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int direction;

    private void Awake()
    {
        
    }

    private void Start()
    {
        /*if (!CheckIfMobile.isMobile())
        {
            gameObject.SetActive(false);
        }*/
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Movement.SetDirection(direction);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Movement.SetDirection(-direction);
    }
}
