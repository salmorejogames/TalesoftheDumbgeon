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
    public WeaponController weaponController;
    public Animator animator;

  

    public enum EquipmentParts
    {
        Head,
        Body,
        Legs
    }

    public void ChangeWeapon(BaseWeapon.WeaponType weaponType, Elements.Element element)
    {
        //Debug.Log("Chanwing Weapon: " + direction.ToString() + " " + weaponType.ToString());
        weaponController.ChangeActiveWeapon(weaponType, element);
        //animator.GetCurrentAnimatorClipInfo(0)[0].clip.
    }

    public void UpdateWeaponType(BaseWeapon.WeaponType weaponType)
    {
        animator.SetInteger("Weapon", (int) weaponType);
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
