using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBlessing 
{
    public enum BlessingType
    {
        Heal,
        PowerUp
    }

    public BlessingType Type;
    public float Strength;
    public float Armor;
    public float Speed;
    public float Health;
    public CharacterStats Stats;
    public float Duration;
    
    public BaseBlessing()
    {
        Strength = 0;
        Armor = 0;
        Speed = 0;
        Health = 0;
        Duration = 0;
    }

    public abstract void Activate();
    public abstract void Desactivate();
}
