using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public AnimationDirection north;
    public AnimationDirection south;
    public AnimationDirection east;
    public AnimationDirection west;
    public AnimationDirection northEast;
    public AnimationDirection northWest;
    public AnimationDirection southEast;
    public AnimationDirection southWest;
    
    [SerializeField] private CharacterStats _stats;
    [NonSerialized] public AnimationDirection Current;
    private bool _move;
    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private BaseWeapon.WeaponType _weapon;
    private static readonly int Magic = Animator.StringToHash("Magic");

    public const string PathName = "EquipmentClass/";

    private void Awake()
    {
        _weapon = 0;
        _move = false;
        Current = south;
        Current.gameObject.SetActive(true);
        Current.animator.SetBool(Walk, _move);
    }
    

    public void EquipArmor(BaseArmor newArmor)
    {
        newArmor.AnimationController = this;
        newArmor.Stats = _stats;
        newArmor.Equip();
    }

    public void EquipWeapon(BaseWeapon.WeaponType weaponType, Elements.Element element)
    {
        Debug.Log("ChangeWeapon: " + weaponType);
        south.ChangeWeapon(weaponType, element);
        north.ChangeWeapon(weaponType, element);
        east.ChangeWeapon(weaponType, element);
        west.ChangeWeapon(weaponType, element);
        northEast.ChangeWeapon(weaponType, element);
        northWest.ChangeWeapon(weaponType, element);
        southEast.ChangeWeapon(weaponType, element);
        southWest.ChangeWeapon(weaponType, element);
        _weapon = weaponType;
        Current.UpdateWeaponType(_weapon);
       

    }

    public void ChangeSprite(AnimationDirection.EquipmentParts part, BodyParts.Sex sex, string equipmentName)
    {
        var equipment = Resources.Load<EquipmentClass>(PathName + equipmentName);
        south.ChangeEquipment(equipment.south, part, sex);
        north.ChangeEquipment(equipment.north, part, sex);
        east.ChangeEquipment(equipment.east, part, sex);
        west.ChangeEquipment(equipment.west, part, sex);
        northEast.ChangeEquipment(equipment.northEast, part, sex);
        northWest.ChangeEquipment(equipment.northWest, part, sex);
        southEast.ChangeEquipment(equipment.southEast, part, sex);
        southWest.ChangeEquipment(equipment.southWest, part, sex);
    }
    
    public void ChangeSprite(AnimationDirection.EquipmentParts part, BodyParts.Sex sex, string equipmentName, Elements.Element element)
    {
        var equipment = Resources.Load<EquipmentClass>(PathName + equipmentName);
        south.ChangeEquipment(equipment.south, part, sex,element);
        north.ChangeEquipment(equipment.north, part, sex,element);
        east.ChangeEquipment(equipment.east, part, sex,element);
        west.ChangeEquipment(equipment.west, part, sex,element);
        northEast.ChangeEquipment(equipment.northEast, part, sex,element);
        northWest.ChangeEquipment(equipment.northWest, part, sex,element);
        southEast.ChangeEquipment(equipment.southEast, part, sex,element);
        southWest.ChangeEquipment(equipment.southWest, part, sex,element );
        
    }

    

    public void SetAtacking()
    {
        //Current.Animator.speed = 4f;
        Current.animator.SetTrigger(Attack);
    }
    
    public void SetSpell()
    {
        //Current.Animator.speed = 4f;
        Debug.Log("Spell");
        Current.animator.SetTrigger(Magic);
    }
    public void SetMoving(bool moving)
    {
       
        if(moving==_move)
            return;
        UpdateAnimationSpeed();
        /*
        south.Animator.SetBool(Walk, moving);
        north.Animator.SetBool(Walk, moving);
        east.Animator.SetBool(Walk, moving);
        west.Animator.SetBool(Walk, moving);
        northEast.Animator.SetBool(Walk, moving);
        northWest.Animator.SetBool(Walk, moving);
        southEast.Animator.SetBool(Walk, moving);
        southWest.Animator.SetBool(Walk, moving);*/
        
        Current.UpdateWeaponType(_weapon);
        Current.animator.SetBool(Walk, moving);
        //Debug.Log(moving);
        _move = moving;
    }

    public void UpdateAnimationSpeed()
    {
        Current.animator.speed = _stats.GetSpeedValue();
    }
    public void ChangeAnimation(BodyParts.Direction direction)
    {
        if (direction.Equals(Current.direction))
        {
            //Debug.Log("RETURNED");
            return;
        }
        
        switch (direction)
        {
            case BodyParts.Direction.North:
                Current.gameObject.SetActive(false);
                north.gameObject.SetActive(true);
                Current = north;
                break;
            case BodyParts.Direction.South:
                Current.gameObject.SetActive(false);
                south.gameObject.SetActive(true);
                Current = south;
                break;
            case BodyParts.Direction.East:
                Current.gameObject.SetActive(false);
                east.gameObject.SetActive(true);
                Current = east;
                break;
            case BodyParts.Direction.West:
                Current.gameObject.SetActive(false);
                west.gameObject.SetActive(true);
                Current = west;
                break;
            case BodyParts.Direction.NorthEast:
                Current.gameObject.SetActive(false);
                northEast.gameObject.SetActive(true);
                Current = northEast;
                break;
            case BodyParts.Direction.NorthWest:
                Current.gameObject.SetActive(false);
                northWest.gameObject.SetActive(true);
                Current = northWest;
                break;
            case BodyParts.Direction.SouthEast:
                Current.gameObject.SetActive(false);
                southEast.gameObject.SetActive(true);
                Current = southEast;
                break;
            case BodyParts.Direction.SouthWest:
                Current.gameObject.SetActive(false);
                southWest.gameObject.SetActive(true);
                Current = southWest;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
        Current.animator.SetBool(Walk, _move);
    }
    #region Debug

    [ContextMenu("LoadWarriorHead")]
    private void CM_LoadWarrior()
    {
        ChangeSprite(AnimationDirection.EquipmentParts.Head, BodyParts.Sex.Boy, StaticInfoHolder.Warrior);
    }
    [ContextMenu("LoadWarriorBody")]
    private void CM_LoadBody()
    {
        ChangeSprite(AnimationDirection.EquipmentParts.Body, BodyParts.Sex.Boy, StaticInfoHolder.Warrior);

    }
    [ContextMenu("LoadWarriorLegs")]
    private void CM_LoadLegs()
    {
        ChangeSprite(AnimationDirection.EquipmentParts.Legs, BodyParts.Sex.Boy, StaticInfoHolder.Warrior);

    }
    
    #endregion
}
