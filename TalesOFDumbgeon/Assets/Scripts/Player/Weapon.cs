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
    public float angle;
    public float relativeAngle;
    public bool incapacited;

    // Start is called before the first frame update
    void Start()
    {
        incapacited = false;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = weaponInfo.artwork;
        _collider = gameObject.AddComponent<PolygonCollider2D>();
        _collider.enabled = false;
        _collider.isTrigger = true;
    }

    public void ChangeWeapon(WeaponSO newWeapon)
    {
        weaponInfo = newWeapon;
        _spriteRenderer.sprite = weaponInfo.artwork;
        //Reset Collider
        Destroy(_collider);
        _collider = gameObject.AddComponent<PolygonCollider2D>();
    }
    
    public void SetOrientation(float newAngle)
    {
        angle = newAngle; 
        gameObject.transform.rotation =Quaternion.Euler(
            new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newAngle+relativeAngle));
    }

    public void Atack()
    {
        Debug.Log("Im atacking");
        weaponInfo.Atacar(this);
    }

    public void ReactivateCollider(float time)
    {
        _collider.enabled = true;
        _spriteRenderer.color = Color.yellow;
        Invoke(nameof(DesactivateCollider), time);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(holder.tag) && (other.gameObject.CompareTag("Enemigo") || other.gameObject.CompareTag("Player")))
        {
            CharacterStats enemy = other.gameObject.GetComponent<CharacterStats>();
            float elementMultiplier = Elements.GetElementMultiplier(weaponInfo.element, enemy.element);
            Debug.Log("Dmg base: " + (weaponInfo.dmg + holder.damage) +"Multiplicador de elemento: "  + elementMultiplier + "(" + weaponInfo.element.ToString() + " => " + enemy.element.ToString() + ")");
            enemy.DoDamage((weaponInfo.dmg + holder.damage) * elementMultiplier);
        }
    }

}
