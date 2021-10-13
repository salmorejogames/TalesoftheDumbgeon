using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int direction;

    public void OnPointerDown(PointerEventData eventData)
    {
        Movement.SetDirection(direction);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Movement.SetDirection(-direction);
    }
}
