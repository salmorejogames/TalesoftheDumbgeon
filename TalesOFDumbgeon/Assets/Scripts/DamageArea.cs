using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] private Weapon parent;
    public BaseWeapon.WeaponType attackType;
    public float fixedAnimationTime;
    [Range(0,1)]
    public float percentStartDmg;
    [Range(0,1)]
    public float percentStopDmgg;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(parent.holder.tag) && (other.gameObject.CompareTag("Enemigo") || other.gameObject.CompareTag("Player")))
        {
            CharacterStats enemy = other.gameObject.GetComponentInParent<CharacterStats>();
            enemy.DoDamage(parent.weaponInfo.Dmg + parent.holder.strength,  gameObject.transform.position, parent.weaponInfo.Element);
        }
    }
}
