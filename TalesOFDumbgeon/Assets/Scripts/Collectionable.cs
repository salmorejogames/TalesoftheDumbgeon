using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Collectionable : MonoBehaviour, ICollectable
{
    [SerializeField] private DamageNumber damagePrefab;
    //public CardInfo card;

    
    public void Collect()
    {
        if (SingletoneGameController.CardHolder.CurentCardCount >= CardHolder.MAX_CARDS)
        {
            DamageNumber dmgN = Instantiate(damagePrefab, transform.position, Quaternion.identity);
            dmgN.Inicializar("Inventario lleno", transform);
            return;
        }

        switch (Random.Range(0, 4))
        {
            case 0:
                SingletoneGameController.CardHolder.AddCard(new ArmorCard(SingletoneGameController.PlayerActions.player.IsoRenderer.animatorController));
                break;
            case 1:
                SingletoneGameController.CardHolder.AddCard(new WeaponCard((BaseWeapon.WeaponType)Random.Range(0,6), SingletoneGameController.PlayerActions.player.PlayerActions.weapon));
                break;
            case 2:
                SingletoneGameController.CardHolder.AddCard(new SpellCard(BaseSpell.SpellType.Damage, SingletoneGameController.PlayerActions.player.PlayerActions.weapon));
                break;
            case 3:
                SingletoneGameController.CardHolder.AddCard(new BlessCard(BaseBlessing.BlessingType.Heal));
                break;
        }
        //SingletoneGameController.CardHolder.AddCard(new SpellCard(BaseSpell.SpellType.Damage, SingletoneGameController.PlayerActions.player.PlayerActions.weapon));
        
        Destroy(gameObject);
    }
    
}
