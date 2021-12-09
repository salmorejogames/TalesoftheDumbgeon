using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonDown : MonoBehaviour, IPointerClickHandler
{
    private CardHolder _cardHolder;
    private RectTransform _rectTransform;

    [SerializeField] private float sizeX = 50;
    [SerializeField] private float sizeY = 50;

    private void Awake()
    {
        //Si desactivamos el GO al empezarm no se puede usar getComponent en Start, que se ejecuta despues de inicializar el objeto pero antes de su primer update.
        _rectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _cardHolder = gameObject.transform.parent.gameObject.GetComponent<CardHolder>();
        _rectTransform.localScale = Vector3.one;
        _rectTransform.sizeDelta = new Vector2(sizeX, sizeY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Time.timeScale > 0.0001f)
        {
            _cardHolder.Resize();
            gameObject.SetActive(false);
        }
    }

    public void SetPos(Vector3 pos)
    {
        _rectTransform.localPosition = new Vector3(pos.x + sizeX/2, pos.y, pos.z);
    }
}
