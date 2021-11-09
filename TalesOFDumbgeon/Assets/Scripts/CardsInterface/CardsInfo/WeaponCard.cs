using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCard : BaseCard
{
    public BaseWeapon Weapon;
    
    //Creating Random WeaponCard
    public WeaponCard(BaseWeapon.WeaponType weaponType, Weapon weaponHolder)
    {
        //Make it random 
        switch (weaponType)
        {
            case BaseWeapon.WeaponType.Area:
                Weapon = new AreaWeapon();
                Artwork =  SingletoneGameController.InfoHolder.areaWeaponArtwork;
                break;
            case BaseWeapon.WeaponType.Ranged:
                Weapon = new RangedWeapon();
                Artwork =  SingletoneGameController.InfoHolder.rangedWeaponArtwork;
                break;
            case BaseWeapon.WeaponType.Smashing:
                break;
            case BaseWeapon.WeaponType.Piercing:
                break;
            default:
                Weapon = new AreaWeapon();
                break;
        }
        Weapon.Randomize(1);
        Weapon.SetWeaponHolder(weaponHolder); 
        String[] info = StaticInfoHolder.LoadName(Weapon.AttackType, Weapon.Element);
        CardName = info[0];
        Description = info[1];
        Strength = Weapon.Strength + Weapon.Dmg;
        Armor = Weapon.Armor;
        Speed = Weapon.Speed;
        Health = Weapon.Health;
        Element = Weapon.Element;
        CardHolder = SingletoneGameController.InfoHolder.cartaArma;
    }
    
    //CreatingCard with a Created Weapon
    public WeaponCard(BaseWeapon weapon)
    {
        Weapon = weapon;
        switch (Weapon.AttackType)
        {
            case BaseWeapon.WeaponType.Area:
                Artwork =  SingletoneGameController.InfoHolder.areaWeaponArtwork;
                break;
            case BaseWeapon.WeaponType.Ranged:
                Artwork =  SingletoneGameController.InfoHolder.rangedWeaponArtwork;
                break;
            case BaseWeapon.WeaponType.Smashing:
                break;
            case BaseWeapon.WeaponType.Piercing:
                break;
            default:
                break;
        }
        String[] info = StaticInfoHolder.LoadName(Weapon.AttackType, Weapon.Element);
        CardName = info[0];
        Description = info[1];
        Strength = Weapon.Strength + Weapon.Dmg;
        Armor = Weapon.Armor;
        Speed = Weapon.Speed;
        Health = Weapon.Health;
        Element = Weapon.Element;
        CardHolder = SingletoneGameController.InfoHolder.cartaArma;
    }
    
    public override void CastEffect()
    {
        Weapon.GetWeaponHolder().ChangeWeapon(Weapon);
    }

    public override void Randomize()
    {
        Weapon.Randomize(1);
        String[] info = StaticInfoHolder.LoadName(Weapon.AttackType, Weapon.Element);
        CardName = info[0];
        Description = info[1];
    }
}
