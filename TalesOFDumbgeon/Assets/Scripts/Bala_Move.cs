using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Move : MonoBehaviour
{
    public float AmmoSpeed;
    public float Range;
    public float Damage;
    public Elements.Element Element;
    public bool rotation = false;
    
    public string parentTag;
    public float holderStrength;
    
    private float _runedDistance;
    private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _runedDistance = 0f;
        //Right = X
        _rb.velocity = transform.right * AmmoSpeed;
    }

    private void FixedUpdate()
    {
        _runedDistance += Vector3.Magnitude(transform.right * (AmmoSpeed * Time.fixedDeltaTime));
        if(rotation)
            gameObject.transform.Rotate(new Vector3(0, 0, 1), 360*Time.fixedDeltaTime);
        if (_runedDistance > Range)
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
                impactStats.DoDamage(Damage + holderStrength, gameObject.transform.position, Element);
                Destroy(gameObject);
            }
        }
    }
}
