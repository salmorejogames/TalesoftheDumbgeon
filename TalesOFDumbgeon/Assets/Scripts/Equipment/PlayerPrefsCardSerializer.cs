using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerPrefsCardSerializer 
{

    public static void SaveData(BaseEquipment baseEquipment)
    {
        PlayerPrefs.SetInt("HerencyEquipmentType", (int)baseEquipment.Type);
        PlayerPrefs.SetFloat("HerencyStrength", (int)baseEquipment.Strength);
        PlayerPrefs.SetFloat("HerencyArmor", (int)baseEquipment.Armor);
        PlayerPrefs.SetFloat("HerencySpeed", (int)baseEquipment.Speed);
        PlayerPrefs.SetFloat("HerencyHealth", (int)baseEquipment.Health);
        PlayerPrefs.SetInt("HerencyElement", (int)baseEquipment.Element);
        switch (baseEquipment.Type)
        {
            case BaseEquipment.EquipmentType.Weapon:
                BaseWeapon baseWeapon = (BaseWeapon) baseEquipment;
                PlayerPrefs.SetString("HerencyInfo", (int) baseWeapon.AttackType + "#" + baseWeapon.Dmg.ToString(CultureInfo.InvariantCulture) );
                break;
            case BaseEquipment.EquipmentType.Magic:
                PlayerPrefs.SetString("HerencyInfo", "" + (int) ((BaseSpell) baseEquipment).SpellKind);
                break;
            case BaseEquipment.EquipmentType.Head:
            case BaseEquipment.EquipmentType.Body:
            case BaseEquipment.EquipmentType.Feet:
                BaseArmor baseArmor = (BaseArmor) baseEquipment;
                PlayerPrefs.SetString("HerencyInfo", (int) baseArmor.ArmorType + "#" + (int) baseArmor.Part);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        PlayerPrefs.Save();
    }
    
    public static BaseEquipment LoadData()
    {
        BaseEquipment newEquipment;
        BaseEquipment.EquipmentType equipmentType = (BaseEquipment.EquipmentType) PlayerPrefs.GetInt("HerencyEquipmentType", 0);
        float strength = PlayerPrefs.GetFloat("HerencyStrength", 1);
        float armor = PlayerPrefs.GetFloat("HerencyArmor", 1);
        float speed = PlayerPrefs.GetFloat("HerencySpeed", 1);
        float health = PlayerPrefs.GetFloat("HerencyHealth", 1);
        Elements.Element element = (Elements.Element) PlayerPrefs.GetInt("HerencyElement", 0);
        string[] aditionalInfo = PlayerPrefs.GetString("HerencyInfo", "4#2").Split('#');
        switch (equipmentType)
        {
            case BaseEquipment.EquipmentType.Weapon:
                switch ( (BaseWeapon.WeaponType) int.Parse(aditionalInfo[0]))
                {
                    case BaseWeapon.WeaponType.Area:
                        newEquipment = new AreaWeapon();
                        break;
                    case BaseWeapon.WeaponType.Ranged:
                        newEquipment = new RangedWeapon();
                        break;
                    case BaseWeapon.WeaponType.Smashing:
                        newEquipment = new SmashingWeapon();
                        break;
                    case BaseWeapon.WeaponType.Piercing:
                        newEquipment = new PiercingWeapon();
                        break;
                    case BaseWeapon.WeaponType.Frisbie:
                        newEquipment = new BomerangWeapon();
                        break;
                    case BaseWeapon.WeaponType.Rapier:
                        newEquipment = new RapierWeapon();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                ((BaseWeapon) newEquipment).Dmg = float.Parse(aditionalInfo[1]);
                break;
            case BaseEquipment.EquipmentType.Magic:
                switch ((BaseSpell.SpellType) int.Parse(aditionalInfo[0]))
                {
                    case BaseSpell.SpellType.Damage:
                        newEquipment = new DamageSpell();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            case BaseEquipment.EquipmentType.Head:
            case BaseEquipment.EquipmentType.Body:
            case BaseEquipment.EquipmentType.Feet:
                BaseArmor.ArmorPart armorPart = (BaseArmor.ArmorPart) int.Parse(aditionalInfo[0]); 
                BaseArmor.BodyPart bodyPart = (BaseArmor.BodyPart) int.Parse(aditionalInfo[1]);
                newEquipment = new BaseArmor(bodyPart, armorPart);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        newEquipment.Strength = strength;
        newEquipment.Armor = armor;
        newEquipment.Speed = speed;
        newEquipment.Health = health;
        newEquipment.Element = element;

        return newEquipment;
    }
    
}
