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
    
    private const float attackRange = 120f;
    private const float attackLimit = 0.5f;
    public AtackType atackType;
   

    public override void Atacar(Weapon weaponGO)
    {
        weaponGO.ReactivateCollider(attackDuration);
        weaponGO.IncapacitedFor(attackDuration);
        switch (atackType)
        {
            case AtackType.Slice:
                weaponGO.StartCoroutine(MeleeWeapon.SliceAtack(weaponGO, attackDuration));
                break;
            case AtackType.Penetrate:
                weaponGO.StartCoroutine(MeleeWeapon.PenetrateAtack(weaponGO, attackDuration));
                break;
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
    
    public static IEnumerator PenetrateAtack(Weapon weaponGO, float attackDuration)
    {
        float advanced = 0f;
        while (advanced < attackLimit/2)
        {
            float step = attackLimit / attackDuration * Time.deltaTime;
            advanced += step;
            weaponGO.relativePosition = advanced;
            yield return new WaitForEndOfFrame();
        }
        while (advanced > 0)
        {
            float step = attackLimit / attackDuration * Time.deltaTime;
            advanced -= step;
            weaponGO.relativePosition = advanced;
            yield return new WaitForEndOfFrame();
        }
        //Vector3 localPos2 = weaponGO.gameObject.transform.localPosition;
        //weaponGO.gameObject.transform.localPosition = new Vector3(localPos2.x - advanced, localPos2.y , localPos2.z);
        weaponGO.relativePosition = 0;
        yield return new WaitForEndOfFrame();
    }
}
