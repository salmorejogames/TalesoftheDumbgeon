using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaWeapon : BaseWeapon
{
    private const float attackRange = 120f;
    

    public AreaWeapon()
    {
        AttackSpeed = 0.5f;
        AttackDuration = 0.25f;
        AttackType = WeaponType.Area;
        WeaponSprite = SingletoneGameController.InfoHolder.areaWeapon;
    }
    public override void Atacar()
    {
        WeaponHolder.ReactivateCollider(AttackDuration);
        SingletoneGameController.PlayerActions.DisableMovement(AttackDuration);
        WeaponHolder.StartCoroutine(SliceAtack(WeaponHolder, AttackDuration));
    }
    
    public IEnumerator SliceAtack(Weapon weaponGO, float attackDuration)
    {
        weaponGO.relativeAngle = - attackRange / 2;
        while (weaponGO.relativeAngle < attackRange / 2)
        {
            weaponGO.relativeAngle += attackRange / attackDuration * Time.deltaTime; ;
            yield return new WaitForEndOfFrame();
        }
            
        weaponGO.relativeAngle = 0;
        yield return new WaitForEndOfFrame();
    }
    

}
