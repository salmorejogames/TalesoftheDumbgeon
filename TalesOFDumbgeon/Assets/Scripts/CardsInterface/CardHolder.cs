using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CardHolder : MonoBehaviour
{
    private Vector3 _restPoint;
    private Vector3 _activePoint;
    public bool active;
    private List<RectTransform> cards;
    private RectTransform _thisRect;
    private int _highlitedCard;
    private InputControler _inputControler;
    [SerializeField] private float gap;
    [SerializeField] private Vector2 cardDimensions;
    [SerializeField] private float resizePercent;
    [SerializeField] private GameObject card;
    [SerializeField] private ButtonDown buttonDown;

    void Awake()
    {
        _inputControler = new InputControler();
        _inputControler.Cartas.NuevaCarta.performed += ctx => AddCard("AspectoDelDragon");
        _inputControler.Cartas.SacarCartas.performed += ctx => Resize();
        _inputControler.Cartas.Selection.performed += ctx => MoveSelection(Convert.ToBoolean(ctx.ReadValue<float>()));
        _inputControler.Cartas.EnterSelection.performed += ctx => EnterSelection();
        
        _thisRect = GetComponent<RectTransform>();
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _highlitedCard = -1;
        active = false;
        cards = new List<RectTransform>();
        _restPoint = new Vector3(0, 0, 0);
        _activePoint = new Vector3(_restPoint.x, _restPoint.y + (cardDimensions[1]/2 + gap), _restPoint.z);
        buttonDown = Instantiate(buttonDown, _thisRect.position, Quaternion.identity);
        buttonDown.gameObject.transform.SetParent(this.gameObject.transform);
        buttonDown.gameObject.SetActive(false);
        AddCard("ComerBaguette");
        
    }
    private void MoveSelection(bool right)
    {
        int nextIndex;
        if (!right)
        {
            if (_highlitedCard <= 0)
                nextIndex = cards.Count - 1;
            else
                nextIndex = _highlitedCard - 1;
        }
        else
        {
            if (_highlitedCard >= cards.Count-1)
                nextIndex = 0;
            else
                nextIndex = _highlitedCard + 1;
        }
        cards[nextIndex].gameObject.GetComponent<Card>().SetHighlight(true);
        ResetHighlight();
        _highlitedCard = nextIndex;
    }

    private void EnterSelection()
    {
        if(_highlitedCard>=0 && active)
            DeleteCard(_highlitedCard);
    }

    public void AddCard(string cardName)
    {
        RectTransform newCard = Instantiate(card, _thisRect.position, Quaternion.identity).GetComponent<RectTransform>();
        
        
        newCard.sizeDelta = cardDimensions;
        newCard.SetParent(this.transform);
        newCard.localScale = new Vector3(1, 1, 1);
        newCard.localPosition = _activePoint;
        newCard.gameObject.GetComponent<Card>().CardName = cardName;
        cards.Add(newCard);

        if (!active)
        {
            newCard.localScale = new Vector3(resizePercent, resizePercent, resizePercent);
            newCard.localPosition = _restPoint;
        }
        
        RepositionateCards();

        
    }

    /**
     * Returns x of the last card displayed.
     */
    private void  RepositionateCards()
    {
        float localGap = gap;                       
        float localWidth = cardDimensions[0];       
        if (!active)
        {
            localGap /= 2;                          
            localWidth /= 2;                        
        }
        float width = localWidth * cards.Count + (cards.Count - 1) * localGap;
        float lastCard = localWidth / 2;    
        foreach (var localCard in cards)
        {
            var localPosition = localCard.localPosition;
            localPosition = new Vector3(-(width/2) + lastCard , localPosition.y, localPosition.z);
            localCard.localPosition = localPosition;
            lastCard += localWidth + localGap;
        }

        //if (CheckIfMobile.isMobile())
            buttonDown.SetPos(new Vector3(width/2+gap, cardDimensions[1]/2, 0 ));
        
    }

    public void Resize()
    {
        if (!active)
        {
            foreach (var localCard in cards)
            {
                localCard.localScale = new Vector3(1, 1, 1);
                var localPosition = localCard.localPosition;
                localPosition = new Vector3(localPosition.x, _activePoint.y, localPosition.z);
                localCard.localPosition = localPosition;
            }
            buttonDown.gameObject.SetActive(true);
        }
        else
        {
            foreach (var localCard in cards)
            {
                localCard.localScale = new Vector3(resizePercent, resizePercent, resizePercent);
                var localPosition = localCard.localPosition;
                localPosition = new Vector3(localPosition.x, _restPoint.y, localPosition.z);
                localCard.localPosition = localPosition;
            }
            ResetHighlight();
        }
        active = !active;
        RepositionateCards();
        buttonDown.gameObject.SetActive(active);
    }

    public void DeleteCard(RectTransform oldCard)
    {
        ResetHighlight();
        cards.Remove(oldCard);
        Destroy(oldCard.gameObject);
        RepositionateCards();
        
        if(cards.Count<=0 && active)
            Resize();
    }
    
    public void DeleteCard(int index)
    {
        ResetHighlight();
        GameObject go = cards[index].gameObject;
        go.GetComponent<Card>().StartDelete();
    }

    private void ResetHighlight()
    {
        if(_highlitedCard>=0)
            cards[_highlitedCard].gameObject.GetComponent<Card>().SetHighlight(false);
        _highlitedCard = -1;
    }

    private void OnEnable()
    {
        _inputControler.Enable();
    }

    private void OnDisable()
    {
        _inputControler.Disable();
    }
}
