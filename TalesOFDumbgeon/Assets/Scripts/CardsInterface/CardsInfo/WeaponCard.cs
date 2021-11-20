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
        cardType = CardType.Weapon;
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
                Weapon = new SmashingWeapon();
                Artwork =  SingletoneGameController.InfoHolder.smashingWeaponArtwork;
                break;
            case BaseWeapon.WeaponType.Piercing:
                Weapon = new PiercingWeapon();
                Artwork =  SingletoneGameController.InfoHolder.piercingWeaponArtwork;
                break;
            case BaseWeapon.WeaponType.Frisbie:
                Weapon = new BomerangWeapon();
                Artwork =  SingletoneGameController.InfoHolder.boomerangWeaponArtwork;
                break;
            case BaseWeapon.WeaponType.Rapier:
                Weapon = new RapierWeapon();
                Artwork =  SingletoneGameController.InfoHolder.rapierWeaponArtwork;
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
        cardType = CardType.Weapon;
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
                Artwork =  SingletoneGameController.InfoHolder.smashingWeaponArtwork;
                break;
            case BaseWeapon.WeaponType.Piercing:
                Artwork =  SingletoneGameController.InfoHolder.piercingWeaponArtwork;
                break;
            case BaseWeapon.WeaponType.Frisbie:
                Artwork =  SingletoneGameController.InfoHolder.boomerangWeaponArtwork;
                break;
            case BaseWeapon.WeaponType.Rapier:
                Artwork =  SingletoneGameController.InfoHolder.rapierWeaponArtwork;
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
}
