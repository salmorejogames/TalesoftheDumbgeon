using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : BaseEquipment
{

    public enum WeaponType
    {
        Area,
        Ranged,
        Smashing,
        Piercing,
    }
    public Sprite artwork;
    public float dmg;
    public float attackSpeed;
    public float attackDuration;
    public WeaponType weaponType;

    public BaseWeapon()
    {
        
    }
    public abstract void Atacar();
}
