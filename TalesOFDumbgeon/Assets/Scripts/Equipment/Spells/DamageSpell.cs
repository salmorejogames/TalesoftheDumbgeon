using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpell : BaseSpell
{
    
    public float Range;
    public Sprite SpellSprite;
    public float SpellSpeed;
    public float Damage;

    public DamageSpell()
    {
        Range = 10f;
        SpellSpeed = 3f;
        SpellDuration = 0.5f;
        Cooldown = 5f;
        Damage = 10f;
        SpellKind = SpellType.Damage;
        SpellSprite = SingletoneGameController.InfoHolder.dmgSpellSprites[(int)Element+1];
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
        GameObject spell = new GameObject("SpellDMG");
        SpriteRenderer spriteR = spell.AddComponent<SpriteRenderer>();
        Bala_Move spellLogic = spell.AddComponent<Bala_Move>();
        Rigidbody2D rb =spell.AddComponent<Rigidbody2D>();
        spell.transform.localScale = new Vector3(2, 2, 2);
        spriteR.sprite = SpellSprite;
        //spriteR.color = SingletoneGameController.InfoHolder.LoadColor(Element);
        
        rb.bodyType = RigidbodyType2D.Kinematic;
        spellLogic.parentTag = WeaponHolder.holder.gameObject.tag;
        spellLogic.Damage = Damage;
        spellLogic.Element = Element;
        spellLogic.Range = Range;
        spellLogic.AmmoSpeed = SpellSpeed;
        spellLogic.holderStrength = Stats.strength;
        Collider2D collider2D = spell.AddComponent<BoxCollider2D>();
        collider2D.isTrigger = true;
        
        
        var transform = WeaponHolder.transform;
        spell.transform.position = transform.position;
        //Debug.Log(weaponGO.angle);
        spell.transform.rotation =
            Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, WeaponHolder.angle));
        
    }
}
