using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDirection : MonoBehaviour
{

    public SpriteRenderer head;
    public SpriteRenderer body;
    public SpriteRenderer leftArm;
    public SpriteRenderer rightArm;
    public SpriteRenderer leftLeg;
    public SpriteRenderer rightLeg;
    public BodyParts.Direction Direction;

    public enum EquipmentParts
    {
        Head,
        Body,
        Legs
    }

    public void ChangeEquipment(BodyParts sprite, EquipmentParts equipmentParts, BodyParts.Sex sex)
    {
        switch (equipmentParts)
        {
            case EquipmentParts.Head:
                head.sprite = sprite.GetBodyPart(BodyParts.BodyPart.Head, sex);
                break;
            case EquipmentParts.Body:
                body.sprite = sprite.GetBodyPart(BodyParts.BodyPart.Body, sex);
                leftArm.sprite = sprite.GetBodyPart(BodyParts.BodyPart.LeftArm, sex);
                rightArm.sprite = sprite.GetBodyPart(BodyParts.BodyPart.RightArm, sex);
                break;
            case EquipmentParts.Legs:
                leftLeg.sprite = sprite.GetBodyPart(BodyParts.BodyPart.LeftLeg, sex);
                rightLeg.sprite = sprite.GetBodyPart(BodyParts.BodyPart.RightLeg, sex);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(equipmentParts), equipmentParts, null);
        }
    }

    void ChangeColor(Color color)
    {
        //TODO CambiarColor
    }
}
