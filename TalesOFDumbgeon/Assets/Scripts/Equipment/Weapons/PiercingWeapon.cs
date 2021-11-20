using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingWeapon : BaseWeapon
{
    
    public PiercingWeapon()
    {
        AttackSpeed = 0.2f;
        AttackDuration = 0.3f;
        AttackType = WeaponType.Piercing;
    }
    public override void Atacar()
    {
        WeaponHolder.ReactivateCollider();
        //SingletoneGameController.PlayerActions.DisableMovement(AttackDuration);
        //WeaponHolder.holder.Immobilize(AttackDuration);
        //WeaponHolder.StartCoroutine(SliceAtack(WeaponHolder, AttackDuration));
    }


}
