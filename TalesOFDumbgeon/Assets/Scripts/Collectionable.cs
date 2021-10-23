using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectionable : MonoBehaviour, ICollectable
{

    public CardInfo card;

    public void Collect()
    {
        SingletoneGameController.CardHolder.AddCard(card.name);
        Destroy(gameObject);
    }
    
}
