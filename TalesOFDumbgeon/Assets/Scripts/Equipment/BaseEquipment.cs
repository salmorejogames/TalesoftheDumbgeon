using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEquipment 
{
    public enum EquipmentType
    {
        Weapon,
        Magic,
        Head,
        Body,
        Feet
    }

    private const int MinPositivePoints = 1;
    private const int MaxPositivePoints = 5;
    private const int MinNegativePoints = 0;
    private const int MaxNegativePoints = 3;
    
    public EquipmentType Type;
    public float Strength;
    public float Armor;
    public float Speed;
    public float Health;
    public Elements.Element Element;
    public CharacterStats Stats;

    public BaseEquipment()
    {
        Strength = 0;
        Armor = 0;
        Speed = 0;
        Health = 0;
    }
    
    public virtual void Equip()
    {
        int pos = (int) Type;
        if(Stats.equipment[pos]!=null)
            Stats.equipment[pos].Unequip(Stats);
        Stats.equipment[pos] = this;
        Stats.armor += Armor;
        Stats.speed += Speed;
        Stats.maxHealth +=Health;
        Stats.Heal(Health);
        Stats.strength += Strength;
        if (Type == EquipmentType.Body)
            Stats.element = Element;
    }
        
    public virtual void Unequip(CharacterStats stats)
    {
        stats.equipment[(int) Type] = null;
        stats.armor -= Armor;
        stats.speed -= Speed;
        stats.strength -= Strength;
        stats.ReduceMaxHealth(Health);
        if (Type == EquipmentType.Body)
            stats.element = Elements.Element.Caos;
    }

    public virtual void Randomize(int level)
    {
        int posPoints = Random.Range(MinPositivePoints, MaxPositivePoints + 1);
        int negPoints = Random.Range(MinNegativePoints, MaxNegativePoints + 1);
        for (int i = 0; i < posPoints; i++)
        {
            int opcion = Random.Range(0, 4);
            switch (opcion)
            {
                case 0:
                    Strength++;
                    break;
                case 1:
                    Armor++;
                    break;
                case 2:
                    Speed++;
                    break;
                case 3:
                    Health++;
                    break;
            }
        }
        for (int i = 0; i < negPoints; i++)
        {
            int opcion = Random.Range(0, 4);
            switch (opcion)
            {
                case 0:
                    Strength--;
                    break;
                case 1:
                    Armor--;
                    break;
                case 2:
                    Speed--;
                    break;
                case 3:
                    Health--;
                    break;
            }
        }

        Element = Elements.GetRandomElement();
    }
    
}
