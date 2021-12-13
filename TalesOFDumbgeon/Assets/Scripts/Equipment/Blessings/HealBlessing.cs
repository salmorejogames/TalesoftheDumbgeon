using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealBlessing : BaseBlessing
{
    public enum HealingItems
    {
        Chupito,
        Dragon,
        Queso,
        Tortilla
    }

    public HealingItems item;

    public HealBlessing(CharacterStats stats)
    {
        Stats = stats;
        Type = BlessingType.Heal;
        item = (HealingItems) Random.Range(0, 4);
        Duration = -1f;
        LoadHealing();
    }

    public HealBlessing(HealingItems itemH, CharacterStats stats)
    {
        Stats = stats;
        Type = BlessingType.Heal;
        item = itemH;
        Duration = -1f;
        LoadHealing();
    }

    private void LoadHealing()
    {
        switch (item)
        {
            case HealingItems.Chupito:
                Health = Mathf.Ceil(Stats.maxHealth * 0.1f);
                break;
            case HealingItems.Dragon:
                Health = Mathf.Ceil(Stats.maxHealth * 0.35f);
                break;
            case HealingItems.Queso:
                Health = Mathf.Ceil(Stats.maxHealth * 0.5f);
                break;
            case HealingItems.Tortilla:
                Health = Stats.maxHealth;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    public override void Activate()
    {
        Stats.Heal(Health);
    }

    public override void Desactivate()
    {
        Debug.Log("Pa ti pa siempre");
    }
}
