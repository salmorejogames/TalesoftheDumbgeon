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
    public BodyParts.Direction direction;
    

    [NonSerialized] public Animator Animator;

    private void Awake()
    {
        Animator = gameObject.GetComponent<Animator>();
    }

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

    public void ChangeEquipment(BodyParts sprite, EquipmentParts equipmentParts, BodyParts.Sex sex,
        Elements.Element element)
    {
        ChangeEquipment(sprite, equipmentParts, sex);
        ChangeColor(SingletoneGameController.ColorShaders.GetMaterial(element), equipmentParts);
    }

    public void ChangeColor(Material material, EquipmentParts part)
    {
        switch (part)
        {
            case EquipmentParts.Head:
                head.material = material;
                break;
            case EquipmentParts.Body:
                body.material = material;
                leftArm.material = material;
                rightArm.material = material;
                break;
            case EquipmentParts.Legs:
                
                leftLeg.material = material;
                rightLeg.material = material;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(part), part, null);
        }
    }
    
}
