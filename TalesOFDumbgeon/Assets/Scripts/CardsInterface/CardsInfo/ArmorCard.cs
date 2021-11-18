using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorCard : BaseCard
{
    public BaseArmor NewArmor;
    private AnimationDirection.EquipmentParts parts;
    private string equipmentName;
    public ArmorCard(PlayerAnimationController animationController)
    {
        //Make it random 
        NewArmor = new BaseArmor();
        NewArmor.Randomize(1);
        switch (NewArmor.ArmorType)
        {
            case BaseArmor.ArmorPart.Normal:
                equipmentName = StaticInfoHolder.Normal;
                break;
            case BaseArmor.ArmorPart.Wizard:
                Artwork = SingletoneGameController.InfoHolder.wizard[(int) NewArmor.Part];
                equipmentName = StaticInfoHolder.Wizard;
                break;
            case BaseArmor.ArmorPart.Warrior:
                Artwork = SingletoneGameController.InfoHolder.warrior[(int) NewArmor.Part];
                equipmentName = StaticInfoHolder.Warrior;
                break;
            case BaseArmor.ArmorPart.Rogue:
                Artwork = SingletoneGameController.InfoHolder.rogue[(int) NewArmor.Part];
                equipmentName = StaticInfoHolder.Rogue;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        //var equipment = Resources.Load<EquipmentClass>(PlayerAnimationController.PathName + equipmentName);
        switch (NewArmor.Part)
        {
            case BaseArmor.BodyPart.Head:
                parts = AnimationDirection.EquipmentParts.Head;
                break;
            case BaseArmor.BodyPart.Body:
                parts = AnimationDirection.EquipmentParts.Body;
                break;
            case BaseArmor.BodyPart.Legs:
                parts = AnimationDirection.EquipmentParts.Legs;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(NewArmor.Part), NewArmor.Part, null);
        }
        
        NewArmor.AnimationController = animationController; 
        //String[] info = StaticInfoHolder.LoadName(Spell.SpellKind, Spell.Element);
        CardName = equipmentName;
        Description = "xd";
        Armor = NewArmor.Armor;
        Speed = NewArmor.Speed;
        Health = NewArmor.Health;
        Element = NewArmor.Element;
        CardHolder = SingletoneGameController.InfoHolder.cartaArmadura;
    }

    public ArmorCard(BaseArmor baseArmor)
    {
        NewArmor = baseArmor;
        switch (NewArmor.ArmorType)
        {
            case BaseArmor.ArmorPart.Normal:
                equipmentName = StaticInfoHolder.Normal;
                break;
            case BaseArmor.ArmorPart.Wizard:
                equipmentName = StaticInfoHolder.Wizard;
                break;
            case BaseArmor.ArmorPart.Warrior:
                equipmentName = StaticInfoHolder.Warrior;
                break;
            case BaseArmor.ArmorPart.Rogue:
                equipmentName = StaticInfoHolder.Rogue;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        var equipment = Resources.Load<EquipmentClass>(PlayerAnimationController.PathName + equipmentName);
        switch (NewArmor.Part)
        {
            case BaseArmor.BodyPart.Head:
                parts = AnimationDirection.EquipmentParts.Head;
                Artwork = equipment.south.head_male;
                break;
            case BaseArmor.BodyPart.Body:
                parts = AnimationDirection.EquipmentParts.Body;
                Artwork = equipment.south.body_male;
                break;
            case BaseArmor.BodyPart.Legs:
                parts = AnimationDirection.EquipmentParts.Legs;
                Artwork = equipment.south.rightLeg;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(NewArmor.Part), NewArmor.Part, null);
        }

        //String[] info = StaticInfoHolder.LoadName(Spell.SpellKind, Spell.Element);
        CardName = equipmentName;
        Description = "xd";
        Armor = NewArmor.Armor;
        Speed = NewArmor.Speed;
        Health = NewArmor.Health;
        Element = NewArmor.Element;
        CardHolder = SingletoneGameController.InfoHolder.cartaArmadura;
    }

    public override void CastEffect()
    {
        NewArmor.AnimationController.ChangeSprite(parts, BodyParts.Sex.Boy, equipmentName, Element);
        NewArmor.AnimationController.EquipArmor(NewArmor);
    }
}
