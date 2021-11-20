using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClose : MonoBehaviour, IPointerClickHandler
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
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _cardHolder.SwapMode();
    }

    public void SetPos(Vector3 pos)
    {
        _rectTransform.localPosition = new Vector3(pos.x + sizeX/2, pos.y, pos.z);
    }
}
