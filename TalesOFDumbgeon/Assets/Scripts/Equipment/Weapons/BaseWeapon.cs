using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : BaseEquipment
{

    public enum WeaponType
    {
        Area = 4,
        Ranged = 3,
        Smashing = 5,
        Piercing = 1,
        Frisbie = 2,
        Rapier = 0
    }
    public Sprite WeaponSprite;
    public float Dmg;
    public float AttackSpeed;
    public float AttackDuration;
    public WeaponType AttackType;
    protected Weapon WeaponHolder;
    public BaseWeapon()
    {
        Type = EquipmentType.Weapon;
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
        if(WeaponHolder.holder.CompareTag("Player"))
            SingletoneGameController.CardHolder.AddCard(new WeaponCard(this));
    }

    public override void Equip()
    {
        base.Equip();
        if(WeaponHolder.holder.CompareTag("Player"))
            SingletoneGameController.PlayerActions.playerAnimation.EquipWeapon(AttackType, Element);
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
