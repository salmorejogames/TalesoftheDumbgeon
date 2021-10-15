using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHolder : MonoBehaviour
{
    public Vector3 _restPoint;
    public Vector3 _activePoint;
    public bool active;
    private List<RectTransform> cards;
    private RectTransform _thisRect;
    [SerializeField] private float gap;
    [SerializeField] private Vector2 cardDimensions;
    [SerializeField] private float resizePercent;
    [SerializeField] private GameObject card;
    
    // Start is called before the first frame update
    void Start()
    {
        _thisRect = GetComponent<RectTransform>();
        active = false;
        cards = new List<RectTransform>();
        _restPoint = new Vector3(0, 0, 0);
        _activePoint = new Vector3(_restPoint.x, _restPoint.y + (cardDimensions[1]/2 + gap), _restPoint.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Resize();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddCard();
        }
        
    }

    public void AddCard()
    {
        RectTransform newCard = Instantiate(card, _thisRect.position, Quaternion.identity).GetComponent<RectTransform>();
        
        
        newCard.sizeDelta = cardDimensions;
        newCard.SetParent(this.transform);
        newCard.localScale = new Vector3(1, 1, 1);
        newCard.localPosition = _activePoint;
        cards.Add(newCard);

        if (!active)
        {
            newCard.localScale = new Vector3(resizePercent, resizePercent, resizePercent);
            newCard.localPosition = _restPoint;
        }
        
        RepositionateCards();

        
    }

    private void RepositionateCards()
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
                RepositionateCards();
                active = true;
            }
        }
        else
        {
            foreach (var localCard in cards)
            {
                localCard.localScale = new Vector3(resizePercent, resizePercent, resizePercent);
                var localPosition = localCard.localPosition;
                localPosition = new Vector3(localPosition.x, _restPoint.y, localPosition.z);
                localCard.localPosition = localPosition;
                RepositionateCards();
                active = false;
            }
        }
    }

    public void DeleteCard(RectTransform card)
    {
        cards.Remove(card);
        Destroy(card.gameObject);
        RepositionateCards();
    }
    
    public void DeleteCard(int index)
    {
        GameObject go = cards[index].gameObject;
        cards.RemoveAt(index);
        Destroy(card.gameObject);
        RepositionateCards();
    }
}
