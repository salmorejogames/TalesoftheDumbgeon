using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaWeapon : BaseWeapon
{
    private const float attackRange = 120f;
    public Weapon Holder;

    public AreaWeapon()
    {
        weaponType = WeaponType.Area;
        artwork = SingletoneGameController.InfoHolder.areaWeapon;
    }
    public override void Atacar()
    {
        Holder.ReactivateCollider(attackDuration);
        SingletoneGameController.PlayerActions.DisableMovement(attackDuration);
    }
}
