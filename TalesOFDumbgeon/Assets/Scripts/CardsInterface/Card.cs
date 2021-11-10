using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{


    [NonSerialized] public string CardName;
    private CardHolder _cardHolder;
    private RectTransform _rectTransform;
    [SerializeField] private Image holderImage;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image itemImage;
    [SerializeField] private CardInfo cardInfo;
    [SerializeField] private Color highlightColor;
    [SerializeField] private float fadeTime;
    [SerializeField] private int distanceLaunch;
    
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = gameObject.GetComponent<RectTransform>();
        _cardHolder = gameObject.transform.parent.gameObject.GetComponent<CardHolder>();
        cardInfo = Resources.Load<CardInfo>("cards/CardsInfo/" + CardName);
        Debug.Log(CardName + " " + cardInfo.cardName);
        holderImage.sprite = cardInfo.cardHolder;
        itemImage.sprite = cardInfo.artwork;
        title.text = cardInfo.cardName;
        description.text = cardInfo.description;
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
        Invoke(nameof(Delete), fadeTime);
    }
    private void Delete()
    {
        ActivateEffect();
        _cardHolder.DeleteCard(_rectTransform);
    }

    public void SetHighlight(bool active)
    {
        if (active)
            holderImage.color = highlightColor;
        else
            holderImage.color = Color.white;
    }
    IEnumerator Fade() {
        Image image = GetComponent<Image>();
        var color = image.color;
        float elapsedTime = 0;
        while (elapsedTime<fadeTime)
        {
            float step = 1 / fadeTime * Time.deltaTime;
            float stepPos = distanceLaunch / fadeTime * Time.deltaTime;
            var tempColor = color;
            tempColor.a = color.a - step;
            image.color = tempColor;
            color = tempColor;
            var localPosition = _rectTransform.localPosition;
            var localScale = _rectTransform.localScale;
            //var localRotation = _rectTransform.localEulerAngles;
            
            localPosition = new Vector3(localPosition.x, localPosition.y + stepPos, localPosition.z);
            _rectTransform.localPosition = localPosition;
           
            localScale = new Vector3(localScale.x - step, localScale.y - step, localScale.z - step);
            _rectTransform.localScale = localScale;
            /*
            localRotation = new Vector3(localRotation.x - 0.5f, localRotation.y, localRotation.z);
            _rectTransform.eulerAngles = localRotation;
            */
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
