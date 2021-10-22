using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public WeaponSO weaponInfo;
    private SpriteRenderer _spriteRenderer;
    public CharacterStats holder;
    private Collider2D _collider;
    [NonSerialized] public float angle;
    [NonSerialized] public float relativeAngle;
    [NonSerialized] public float relativePosition;
    [NonSerialized] public bool incapacited;
    

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        incapacited = false;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ChangeWeapon(weaponInfo);
    }

    public void ChangeWeapon(WeaponSO newWeapon)
    {
        if (weaponInfo != null)
            weaponInfo.Unequip(holder);
        //Reset Collider
        if(_collider!= null)
            Destroy(_collider);
        
        
        weaponInfo = newWeapon;
        weaponInfo.Equip(holder);
        _spriteRenderer.sprite = weaponInfo.artwork;
        _collider = gameObject.AddComponent<PolygonCollider2D>();
        _collider.enabled = false;
        _collider.isTrigger = true;
    }
    
    public void SetOrientation(float newAngle)
    {
        angle = newAngle; 
        gameObject.transform.rotation =Quaternion.Euler(
            new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle+relativeAngle));
    }

    public void Atack()
    {
        Debug.Log("Im atacking");
        weaponInfo.Atacar(this);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(holder.tag) && (other.gameObject.CompareTag("Enemigo") || other.gameObject.CompareTag("Player")))
        {
            CharacterStats enemy = other.gameObject.GetComponent<CharacterStats>();
            enemy.DoDamage(IsometricUtils.CalculateDamage(weaponInfo.dmg, holder.strength, weaponInfo.element, enemy.element));
        }
    }
    
    ////Activate and Desactivate Elements
    public void ReactivateCollider(float time)
    {
        _collider.enabled = true;
        _spriteRenderer.color = Color.yellow;
        Invoke(nameof(DesactivateCollider), time);
    }

    public void UpdatePosition(Vector3 newCenter)
    {
        gameObject.transform.position = newCenter;
        gameObject.transform.position += gameObject.transform.right * relativePosition;
    }

    public void DesactivateCollider()
    {
        _spriteRenderer.color = Color.white;
        _collider.enabled = false;
    }

    public void IncapacitedFor(float time)
    {
        incapacited = true;
        Invoke(nameof(Reactivate), time);
    }

    public void Reactivate()
    {
        incapacited = false;
    }
}
