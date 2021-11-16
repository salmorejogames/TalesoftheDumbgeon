﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectionable : MonoBehaviour, ICollectable
{

    //public CardInfo card;

    
    public void Collect()
    {
        //SingletoneGameController.CardHolder.AddCard(new SpellCard(BaseSpell.SpellType.Damage, SingletoneGameController.PlayerActions.player.PlayerActions.weapon));
        SingletoneGameController.CardHolder.AddCard(new ArmorCard(SingletoneGameController.PlayerActions.player
            .IsoRenderer.animatorController));
        Destroy(gameObject);
    }
    
}
