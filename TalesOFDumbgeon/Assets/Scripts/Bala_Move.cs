using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Move : MonoBehaviour
{
    //public RangedWeapon weapon;
    public string parentTag;
    public float holderStrength;
    
    private float _runedDistance;
    private Rigidbody2D _rb;


/*
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _runedDistance = 0f;
        //Right = X
        /_rb.velocity = transform.right * weapon.ammoSpeed;
    }

    private void FixedUpdate()
    {
        _runedDistance += Vector3.Magnitude(transform.right * (weapon.ammoSpeed * Time.fixedDeltaTime));
        if (_runedDistance > weapon.range)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject impact = collision.gameObject;
        if (impact.CompareTag("Escenario"))
        {
            Destroy(gameObject);
        }
        if (impact.CompareTag("Player") || impact.CompareTag("Enemigo"))
        {
            if (!impact.CompareTag(parentTag))
            {
                CharacterStats impactStats = impact.GetComponent<CharacterStats>();
                impactStats.DoDamage(weapon.dmg + holderStrength, gameObject, weapon.element);
                Destroy(gameObject);
            }
        }
    }*/
}
