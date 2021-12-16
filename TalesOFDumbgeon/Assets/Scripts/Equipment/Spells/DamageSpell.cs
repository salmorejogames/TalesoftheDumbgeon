using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpell : BaseSpell
{
    
    public float Range;
    public Sprite SpellSprite;
    public float SpellSpeed;
    public float Damage;
    private GameObject spellPrefab;

    public DamageSpell()
    {
        Range = 10f;
        SpellSpeed = 3f;
        SpellDuration = 0.5f;
        Cooldown = 5f;
        Damage = 10f;
        SpellKind = SpellType.Damage;
        SpellSprite = SingletoneGameController.InfoHolder.dmgSpellSprites[(int)Element+1];
        spellPrefab = SingletoneGameController.InfoHolder.hechizo;
    }

    public override void Cast()
    {
        WeaponHolder.holder.Immobilize(SpellDuration);
        WeaponHolder.holder.StartCoroutine(LaunchSpell());

        //Debug.Log(ammo.transform.rotation.eulerAngles.ToString());
    }

    public override void Randomize(int level)
    {
        base.Randomize(level);
        SpellSprite = SingletoneGameController.InfoHolder.dmgSpellSprites[(int)Element+1];
    }

    private IEnumerator LaunchSpell()
    {
        yield return new WaitForSeconds(SpellDuration*2/3);
        var transform = WeaponHolder.transform;
        GameObject spell = Object.Instantiate(spellPrefab, transform.position, Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, WeaponHolder.angle)), SingletoneGameController.MapManager.ActualMap.gameObject.transform);
        SpriteRenderer spriteR = spell.GetComponent<SpriteRenderer>();
        Bala_Move spellLogic = spell.GetComponent<Bala_Move>();

        spriteR.sprite = SpellSprite;
        //spriteR.color = SingletoneGameController.InfoHolder.LoadColor(Element);
        
        spellLogic.rotation = true;
        spellLogic.parentTag = WeaponHolder.holder.gameObject.tag;
        spellLogic.Damage = Damage;
        spellLogic.Element = Element;
        spellLogic.Range = Range;
        spellLogic.AmmoSpeed = SpellSpeed;
        spellLogic.holderStrength = Stats.strength;
       
    }
}
