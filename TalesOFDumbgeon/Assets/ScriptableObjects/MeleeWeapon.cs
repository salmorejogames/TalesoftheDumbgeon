using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/MeleeWeapon")]
public class MeleeWeapon : WeaponSO
{
    public enum AtackType
    {
        Slice,
        Penetrate
    }
    private const float attackRange = 180f;

  
    public AtackType atackType;
   

    public override void Atacar(Weapon weaponGO)
    {
        weaponGO.ReactivateCollider(attackDuration);
        weaponGO.IncapacitedFor(attackDuration);
        switch (atackType)
        {
            case AtackType.Slice:
                weaponGO.StartCoroutine(MeleeWeapon.SliceAtack(weaponGO, attackDuration));
                return;
        }
    }

    public static IEnumerator SliceAtack(Weapon weaponGO, float attackDuration)
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
