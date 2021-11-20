using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemCard : MonoBehaviour, IPointerClickHandler
{
    [NonSerialized] public int CardType;
    [NonSerialized] public int CardId;
    public BaseCard CardInfo = null;
    
    private CardHolder _cardHolder;
    private RectTransform _rectTransform;
    [SerializeField] private Image holderImage;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI strength;
    [SerializeField] private TextMeshProUGUI armor;
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private Image itemImage;
    [SerializeField] private Color highlightColor;
    [SerializeField] private float fadeTime;
    [SerializeField] private int distanceLaunch;

    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = gameObject.GetComponent<RectTransform>();
        _cardHolder = gameObject.transform.parent.gameObject.GetComponent<CardHolder>();
        if (CardInfo == null)
        {
            switch ((BaseCard.CardType) CardType)
            {
                case BaseCard.CardType.Weapon:
                    CardInfo = new WeaponCard((BaseWeapon.WeaponType) CardId, SingletoneGameController.PlayerActions.player.PlayerActions.weapon);
                    break;
                case BaseCard.CardType.Equipment:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        holderImage.sprite = CardInfo.CardHolder;
        itemImage.sprite = CardInfo.Artwork;
        itemImage.color = SingletoneGameController.InfoHolder.LoadColor(CardInfo.Element);
        title.text = CardInfo.CardName;
        description.text = CardInfo.Description;
        armor.text = CardInfo.Armor.ToString();
        strength.text = CardInfo.Strength.ToString();
        speed.text = CardInfo.Speed.ToString();
        health.text = CardInfo.Health.ToString();
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
        CardInfo.CastEffect();
        SingletoneGameController.InterfaceController.CambiarSprite(CardInfo.cardType, CardInfo.Artwork);
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
