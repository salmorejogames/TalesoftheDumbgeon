using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCard 
{
    public string CardName;
    public string Description;
    public Sprite CardHolder;
    public Sprite Artwork;
    
    public float Strength;
    public float Armor;
    public float Speed;
    public float Health;
    public Elements.Element Element;
    
    public enum CardType
    {
        Weapon,
        Equipment
    }

    public BaseCard()
    {
        Strength = 0;
        Armor = 0;
        Speed = 0;
        Health = 0;
        Element = Elements.Element.Caos;
    }

    public abstract void CastEffect();

    public abstract void Randomize();
}
