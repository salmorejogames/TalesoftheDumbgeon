using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCard : BaseCard
{
    public BaseSpell Spell;

    public SpellCard(BaseSpell.SpellType spellType, Weapon weaponHolder)
    {
        //Make it random 
        switch (spellType)
        {
            case BaseSpell.SpellType.Damage:
                Spell = new DamageSpell();
                Artwork = SingletoneGameController.InfoHolder.dmgSpellArtwork;
                Strength = Spell.Strength + ((DamageSpell) Spell).Damage;
                break;
            case BaseSpell.SpellType.Hability:
                Strength = Spell.Strength;
                break;
            case BaseSpell.SpellType.EspecialDmg:
                Strength = Spell.Strength;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(spellType), spellType, null);
        }
        Spell.Randomize(1);
        Spell.SetWeaponHolder(weaponHolder); 
        String[] info = StaticInfoHolder.LoadName(Spell.SpellKind, Spell.Element);
        CardName = info[0];
        Description = info[1];
        Armor = Spell.Armor;
        Speed = Spell.Speed;
        Health = Spell.Health;
        Element = Spell.Element;
        CardHolder = SingletoneGameController.InfoHolder.cartaHechizo;
    }

    public SpellCard(BaseSpell baseSpell)
    {
        Spell = baseSpell;
        switch (Spell.SpellKind)
        {
            case BaseSpell.SpellType.Damage:
                Artwork = SingletoneGameController.InfoHolder.dmgSpellArtwork;
                Strength = Spell.Strength + ((DamageSpell) Spell).Damage;
                break;
            case BaseSpell.SpellType.Hability:
                Strength = Spell.Strength;
                break;
            case BaseSpell.SpellType.EspecialDmg:
                Strength = Spell.Strength;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        String[] info = StaticInfoHolder.LoadName(Spell.SpellKind, Spell.Element);
        CardName = info[0];
        Description = info[1];
        Armor = Spell.Armor;
        Speed = Spell.Speed;
        Health = Spell.Health;
        Element = Spell.Element;
        CardHolder = SingletoneGameController.InfoHolder.cartaHechizo;
    }
    public override void CastEffect()
    {
        Spell.GetWeaponHolder().ChangeSpell(Spell);
    }
}
