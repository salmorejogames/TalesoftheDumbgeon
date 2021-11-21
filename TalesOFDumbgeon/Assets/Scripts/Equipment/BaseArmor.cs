using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BaseArmor : BaseEquipment
{
    public enum BodyPart
    {
        Head,
        Body,
        Legs
    }

    public enum ArmorPart
    {
        Normal,
        Wizard,
        Warrior,
        Rogue
    }

    public PlayerAnimationController AnimationController;
    public BodyPart Part;
    public ArmorPart ArmorType;

    public BaseArmor()
    {
    }
    
    public BaseArmor(BodyPart bodyPart, ArmorPart armorPart)
    {
        Part = bodyPart;
        ArmorType = armorPart;
        switch (Part)
        {
            case BodyPart.Head:
                Type = EquipmentType.Head;
                break;
            case BodyPart.Body:
                Type = EquipmentType.Body;
                break;
            case BodyPart.Legs:
                Type = EquipmentType.Feet;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public virtual void OnHit() { }
    public override void Randomize(int level)
    {
        base.Randomize(level);
        Part = (BodyPart) Random.Range(0, 3);
        ArmorType = (ArmorPart) Random.Range(1, 4);
        switch (ArmorType)
        {
            case ArmorPart.Normal:
                Armor+=1;
                break;
            case ArmorPart.Wizard:
                Health += 1;
                break;
            case ArmorPart.Warrior:
                Strength += 1;
                break;
            case ArmorPart.Rogue:
                Speed += 1;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        switch (Part)
        {
            case BodyPart.Head:
                Type = EquipmentType.Head;
                break;
            case BodyPart.Body:
                Type = EquipmentType.Body;
                break;
            case BodyPart.Legs:
                Type = EquipmentType.Feet;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public override void Unequip()
    {
        base.Unequip();
        if (AnimationController.gameObject.transform.parent.CompareTag("Player")) 
            SingletoneGameController.CardHolder.AddCard(new ArmorCard(this));
    }
}
