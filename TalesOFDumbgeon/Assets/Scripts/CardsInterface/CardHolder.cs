﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHolder : MonoBehaviour
{
    private Vector3 _restPoint;
    private Vector3 _activePoint;
    public bool active;
    private List<RectTransform> cards;
    private RectTransform _thisRect;
    private int _highlitedCard;
    [SerializeField] private float gap;
    [SerializeField] private Vector2 cardDimensions;
    [SerializeField] private float resizePercent;
    [SerializeField] private GameObject card;
    [SerializeField] private ButtonDown buttonDown;
    
    // Start is called before the first frame update
    void Start()
    {
        _highlitedCard = -1;
        _thisRect = GetComponent<RectTransform>();
        active = false;
        cards = new List<RectTransform>();
        _restPoint = new Vector3(0, 0, 0);
        _activePoint = new Vector3(_restPoint.x, _restPoint.y + (cardDimensions[1]/2 + gap), _restPoint.z);
        buttonDown = Instantiate(buttonDown, _thisRect.position, Quaternion.identity);
        buttonDown.gameObject.transform.SetParent(this.gameObject.transform);
        buttonDown.gameObject.SetActive(false);
        
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
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (active && cards.Count>0)
            {
                int nextIndex;
                if (_highlitedCard <= 0)
                    nextIndex = cards.Count - 1;
                else
                    nextIndex = _highlitedCard - 1;
                cards[nextIndex].gameObject.GetComponent<Card>().SetHighlight(true);
                ResetHighlight();
                _highlitedCard = nextIndex;
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (active && cards.Count>0)
            {
                int nextIndex;
                if (_highlitedCard >= cards.Count-1)
                    nextIndex = 0;
                else
                    nextIndex = _highlitedCard + 1;
                cards[nextIndex].gameObject.GetComponent<Card>().SetHighlight(true);
                ResetHighlight();
                _highlitedCard = nextIndex;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_highlitedCard>=0 && active)
                DeleteCard(_highlitedCard);
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
        Debug.Log(width);
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
                RepositionateCards();
                //if (CheckIfMobile.isMobile()) 
                    buttonDown.gameObject.SetActive(true);
                    
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
                ResetHighlight();
                //if (CheckIfMobile.isMobile())
                    buttonDown.gameObject.SetActive(false);
                active = false;
                
            }
        }
    }

    public void DeleteCard(RectTransform oldCard)
    {
        ResetHighlight();
        cards.Remove(oldCard);
        Destroy(oldCard.gameObject);
        RepositionateCards();
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
}