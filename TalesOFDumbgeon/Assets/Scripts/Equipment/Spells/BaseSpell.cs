using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : BaseEquipment
{
    public enum SpellType
    {
        Damage,
        Hability,
        EspecialDmg
    }

    public float Cooldown;
    protected Weapon WeaponHolder;
    public float SpellDuration;
    public SpellType SpellKind;

    public BaseSpell()
    {
        Type = EquipmentType.Magic;
    }

    public abstract void Cast();
    public override void Randomize(int level)
    {
        base.Randomize(level);
        Strength = 0;
        Armor = 0;
        Speed = 0;
        Health = 0;
    }
    public override void Unequip()
    {
        base.Unequip();
        if (WeaponHolder.holder.CompareTag("Player"))
            SingletoneGameController.CardHolder.AddCard(new SpellCard(this));
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
