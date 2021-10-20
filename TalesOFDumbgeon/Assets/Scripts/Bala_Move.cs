using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Move : MonoBehaviour
{
    public RangedWeapon weapon;
    public string parentTag;
    public float holderAtack;
    private float _runDistance;
    private Vector3 _lastPoint;
    private Rigidbody2D _rb;



    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _runDistance = 0f;
        _lastPoint = gameObject.transform.position;
        GetComponent<Rigidbody2D>().velocity = transform.up * weapon.ammoSpeed;
    }

    private void FixedUpdate()
    {
        //transform.position = transform.position + transform.up * (weapon.ammoSpeed * Time.fixedDeltaTime);
        _runDistance += Vector3.Distance(_lastPoint, gameObject.transform.position);
        _lastPoint = gameObject.transform.position;
        //Debug.Log( transform.up + " " +weapon.ammoSpeed + " " +  Time.fixedDeltaTime + " " + _runDistance);
        if (_runDistance > weapon.range)
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
                impactStats.DoDamage((holderAtack+ weapon.dmg)*Elements.GetElementMultiplier(weapon.element, impactStats.element));
                Destroy(gameObject);
            }
        }
    }
}
