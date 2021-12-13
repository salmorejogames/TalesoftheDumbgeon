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
    [SerializeField] private Color deleteColor;
    [SerializeField] private float fadeTime;
    [SerializeField] private int distanceLaunch;
    private bool cardReady;

    private bool deleteMode = false;
    // Start is called before the first frame update
    void Start()
    {
        cardReady = true;
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
                    CardInfo = new ArmorCard(SingletoneGameController.PlayerActions.playerAnimation);
                    break;
                case BaseCard.CardType.Spell:
                    CardInfo = new SpellCard((BaseSpell.SpellType) CardId,
                        SingletoneGameController.PlayerActions.player.PlayerActions.weapon);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        holderImage.sprite = CardInfo.CardHolder;
        itemImage.sprite = CardInfo.Artwork;
        if(CardInfo.cardType != BaseCard.CardType.Spell && CardInfo.cardType != BaseCard.CardType.Bless)
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
        if (cardReady && Time.timeScale > 0.0001f)
        {
            if (_cardHolder.active)
            {
                StartDelete(_cardHolder.modeDelete);
            }
            else
            {
                _cardHolder.Resize();
            }
        }
    }

    public void ActivateEffect()
    {
        CardInfo.CastEffect();

        BaseArmor.BodyPart bodyPart = BaseArmor.BodyPart.Body;
        if (CardInfo.cardType == BaseCard.CardType.Equipment)
        {
            bodyPart = ((ArmorCard)CardInfo).NewArmor.Part;
        }

        SingletoneGameController.InterfaceController.CambiarSprite(CardInfo.cardType, bodyPart, CardInfo.Artwork, CardInfo.Element);
    }

    public void StartDelete(bool modeDelete)
    {
        deleteMode = modeDelete;
        cardReady = false;
        SetHighlight(false);
        StartCoroutine(nameof(Fade));
        Invoke(nameof(Delete), fadeTime);
    }
    private void Delete()
    {
        if(!deleteMode)
            ActivateEffect();
        _cardHolder.DeleteCard(_rectTransform);
    }

    public void SetHighlight(bool active)
    {
        if (active)
            holderImage.color = highlightColor;
        else if (_cardHolder.modeDelete)
            holderImage.color = deleteColor;
        else
            holderImage.color = Color.white;
    }

    public void SetDeleteleColor(bool active)
    {
        if (active)
            holderImage.color = deleteColor;
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
