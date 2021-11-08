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
    public Sprite WeaponSprite;
    public float Dmg;
    public float AttackSpeed;
    public float AttackDuration;
    public WeaponType AttackType;
    protected Weapon WeaponHolder;
    public BaseWeapon()
    {
        
    }
    public abstract void Atacar();

    public override void Randomize(int level)
    {
        base.Randomize(level);
        Dmg = Random.Range(1, 4);
    }

    public override void Unequip()
    {
        base.Unequip();
        SingletoneGameController.CardHolder.AddCard(new WeaponCard(this));
    }

    public Weapon GetWeaponHolder()
    {
        return WeaponHolder;
    }

    public void SetWeaponHolder(Weapon weaponHolder)
    {
        WeaponHolder = weaponHolder;
        Stats = weaponHolder.holder;
    }
}
