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

    [NonSerialized] public AnimationDirection Current;
    private bool _move;
    private static readonly int Walk = Animator.StringToHash("Walk");

    public const string PathName = "EquipmentClass/";

    private void Awake()
    {
        _move = false;
        Current = south;
        Current.gameObject.SetActive(true);
        Current.Animator.SetBool(Walk, _move);
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

    public void SetMoving(bool moving)
    {
        if(moving==_move)
            return;
        /*
        south.Animator.SetBool(Walk, moving);
        north.Animator.SetBool(Walk, moving);
        east.Animator.SetBool(Walk, moving);
        west.Animator.SetBool(Walk, moving);
        northEast.Animator.SetBool(Walk, moving);
        northWest.Animator.SetBool(Walk, moving);
        southEast.Animator.SetBool(Walk, moving);
        southWest.Animator.SetBool(Walk, moving);*/
        Current.Animator.SetBool(Walk, moving);
        //Debug.Log(moving);
        _move = moving;
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
        Current.Animator.SetBool(Walk, _move);
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
