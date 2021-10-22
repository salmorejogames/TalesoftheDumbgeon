using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/RangedWeapon")]
public class RangedWeapon : WeaponSO
{
    public Sprite ammoSprite;
    public float range;
    public float ammoSpeed;
    

    public override void Atacar(Weapon weaponGO)
    {
        SingletoneGameController.PlayerActions.DisableMovement(attackDuration);
        GameObject ammo = new GameObject("Ammo");
        
        
        SpriteRenderer spriteR = ammo.AddComponent<SpriteRenderer>();
        Bala_Move bala = ammo.AddComponent<Bala_Move>();
        Rigidbody2D rb =ammo.AddComponent<Rigidbody2D>();
        
        spriteR.sprite = ammoSprite;
        spriteR.sortingLayerName = "H2";
        rb.bodyType = RigidbodyType2D.Kinematic;
        bala.parentTag = weaponGO.holder.gameObject.tag;
        bala.weapon = this;
        bala.holderStrength = weaponGO.holder.GetComponent<CharacterStats>().strength;
        Collider2D collider2D = ammo.AddComponent<PolygonCollider2D>();
        collider2D.isTrigger = true;
        
        var transform = weaponGO.transform;
        ammo.transform.position = transform.position;
        Debug.Log(weaponGO.angle);
        ammo.transform.rotation =
            Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, weaponGO.angle));;
        Debug.Log(ammo.transform.rotation.eulerAngles.ToString());
    }
}
