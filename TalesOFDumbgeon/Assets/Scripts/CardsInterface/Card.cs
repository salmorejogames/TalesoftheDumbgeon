using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{


    public string cardName;
    private CardHolder _cardHolder;
    private RectTransform _rectTransform;
    private Image _image;
    [SerializeField] private CardInfo cardInfo;
    [SerializeField] private Color highlightColor;
    
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = gameObject.GetComponent<RectTransform>();
        _cardHolder = gameObject.transform.parent.gameObject.GetComponent<CardHolder>();
        _image = gameObject.GetComponent<Image>();
        cardInfo = Resources.Load<CardInfo>("cards/CardsInfo/" + cardName);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_cardHolder.active)
        {
           StartDelete();
        }
        else
        {
            _cardHolder.Resize();
        }
        
    }

    public void ActivateEffect()
    {
        cardInfo.CastEffect();
    }

    public void StartDelete()
    {
        SetHighlight(false);
        StartCoroutine(nameof(Fade));
        Invoke(nameof(Delete), 1);
        ActivateEffect();
    }
    private void Delete()
    {
        _cardHolder.DeleteCard(_rectTransform);
    }

    public void SetHighlight(bool active)
    {
        if (active)
            _image.color = highlightColor;
        else
            _image.color = Color.white;
    }
    IEnumerator Fade() {
        Image image = GetComponent<Image>();
        var color = image.color;
        while (true)
        {
            var tempColor = color;
            tempColor.a = color.a - 0.01f;
            image.color = tempColor;
            color = tempColor;
            var localPosition = _rectTransform.localPosition;
            var localScale = _rectTransform.localScale;
            //var localRotation = _rectTransform.localEulerAngles;
            
            localPosition = new Vector3(localPosition.x, localPosition.y + 1.0f, localPosition.z);
            _rectTransform.localPosition = localPosition;
           
            localScale = new Vector3(localScale.x - 0.005f, localScale.y - 0.005f, localScale.z - 0.005f);
            _rectTransform.localScale = localScale;
            /*
            localRotation = new Vector3(localRotation.x - 0.5f, localRotation.y, localRotation.z);
            _rectTransform.eulerAngles = localRotation;
            */
            yield return null;
        }
    }
}
