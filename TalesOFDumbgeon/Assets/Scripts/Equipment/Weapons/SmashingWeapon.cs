using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashingWeapon : BaseWeapon
{
    
    public SmashingWeapon()
    {
        AttackSpeed = 0.2f;
        AttackDuration = 0.3f;
        AttackType = WeaponType.Smashing;
    }
    public override void Atacar()
    {
        WeaponHolder.ReactivateCollider();
        //SingletoneGameController.PlayerActions.DisableMovement(AttackDuration);
        //WeaponHolder.holder.Immobilize(AttackDuration);
        //WeaponHolder.StartCoroutine(SliceAtack(WeaponHolder, AttackDuration));
    }


}
