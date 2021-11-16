using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Body Sprite", menuName = "Equipment/BodySprite")]
public class BodyParts : ScriptableObject
{
    public enum Direction
    {
        North = 2,
        South = 6,
        East = 0,
        West = 4,
        NorthEast = 1,
        NorthWest = 3,
        SouthEast = 7,
        SouthWest = 5
    }

    public enum Sex
    {
        Boy,
        Girl
    }

    public enum BodyPart
    {
        Head = 0,
        Body = 1,
        LeftArm = 2,
        RightArm = 3,
        LeftLeg = 4,
        RightLeg = 5
    }
    
    public Sprite head_male;
    public Sprite head_female;
    public Sprite body_male;
    public Sprite body_female;
    public Sprite leftArm;
    public Sprite rightArm;
    public Sprite leftLeg;
    public Sprite rightLeg;
    public Direction direction;

    public Sprite GetBodyPart(int bodyPart, Sex sex)
    {
        switch ((BodyPart) bodyPart)
        {
            case BodyPart.Head:
                return sex == Sex.Boy ? head_male : head_female;
            case BodyPart.Body:
                return sex == Sex.Boy ? body_male : body_female;
            case BodyPart.LeftArm:
                return leftArm;
            case BodyPart.RightArm:
                return rightArm;
            case BodyPart.LeftLeg:
                return leftLeg;
            case BodyPart.RightLeg:
                return rightLeg;
            default:
                throw new ArgumentOutOfRangeException(nameof(bodyPart), bodyPart, null);
        }
    }
    
    public Sprite GetBodyPart(BodyPart bodyPart, Sex sex)
    {
        switch ( bodyPart)
        {
            case BodyPart.Head:
                return sex == Sex.Boy ? head_male : head_female;
            case BodyPart.Body:
                return sex == Sex.Boy ? body_male : body_female;
            case BodyPart.LeftArm:
                return leftArm;
            case BodyPart.RightArm:
                return rightArm;
            case BodyPart.LeftLeg:
                return leftLeg;
            case BodyPart.RightLeg:
                return rightLeg;
            default:
                throw new ArgumentOutOfRangeException(nameof(bodyPart), bodyPart, null);
        }
    }



}
