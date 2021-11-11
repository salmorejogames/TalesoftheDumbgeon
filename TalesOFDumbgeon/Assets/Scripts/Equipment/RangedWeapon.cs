using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : BaseWeapon
{

    public float Range;
    public Sprite AmmoSprite;
    public float AmmoSpeed;

    public RangedWeapon()
    {
        Range = 10f;
        AmmoSpeed = 3f;
        AttackSpeed = 0.5f;
        AttackDuration = 0.1f;
        AttackType = WeaponType.Ranged;
        WeaponSprite = SingletoneGameController.InfoHolder.rangedWeapon;
        AmmoSprite = SingletoneGameController.InfoHolder.ammoSprite;

    }

    public RangedWeapon(float range, float ammoSpeed)
    {
        Range = range;
        AmmoSpeed = ammoSpeed;
        AttackSpeed = 0.5f;
        AttackDuration = 0.1f;
        AttackType = WeaponType.Ranged;
        WeaponSprite = SingletoneGameController.InfoHolder.rangedWeapon;
        AmmoSprite = SingletoneGameController.InfoHolder.ammoSprite;
    }
    public override void Atacar()
    {
        SingletoneGameController.PlayerActions.DisableMovement(AttackDuration);
        GameObject ammo = new GameObject("Ammo");
        
        
        SpriteRenderer spriteR = ammo.AddComponent<SpriteRenderer>();
        Bala_Move bala = ammo.AddComponent<Bala_Move>();
        Rigidbody2D rb =ammo.AddComponent<Rigidbody2D>();
        
        spriteR.sprite = AmmoSprite;
        spriteR.color = SingletoneGameController.InfoHolder.LoadColor(Element);
        
        rb.bodyType = RigidbodyType2D.Kinematic;
        bala.parentTag = WeaponHolder.holder.gameObject.tag;
        bala.weapon = this;
        bala.holderStrength = Stats.strength;
        Collider2D collider2D = ammo.AddComponent<PolygonCollider2D>();
        collider2D.isTrigger = true;
        
        var transform = WeaponHolder.transform;
        ammo.transform.position = transform.position;
        //Debug.Log(weaponGO.angle);
        ammo.transform.rotation =
            Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, WeaponHolder.angle));;
        //Debug.Log(ammo.transform.rotation.eulerAngles.ToString());
    }
}