using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaWeapon : BaseWeapon
{

    

    public AreaWeapon()
    {
        AttackSpeed = 0.2f;
        AttackDuration = 0.25f;
        AttackType = WeaponType.Area;
    }
    public override void Atacar()
    {
        WeaponHolder.ReactivateCollider();
        //SingletoneGameController.PlayerActions.DisableMovement(AttackDuration);
        //WeaponHolder.holder.Immobilize(AttackDuration);
        //WeaponHolder.StartCoroutine(SliceAtack(WeaponHolder, AttackDuration));
    }
    
    

}
