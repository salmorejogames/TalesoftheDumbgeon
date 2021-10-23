using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    
    public float maxHealth;
    public float armor;
    public float strength;
    public Elements.Element element;
    public float speed;
    
    private bool _alive;
    private float _actualHealth;
   
    void Start()
    {
        _alive = true;
        _actualHealth = maxHealth;
    }

    public void DoDamage(float dmg)
    {
        _actualHealth -= Mathf.Clamp(dmg-armor, 0, maxHealth);
        if (_actualHealth <= 0)
            _alive = false;
        Debug.Log(gameObject.name +": Me han hecho " + (dmg-armor) + " de dmg, me quedan " + _actualHealth + " de vida");
    }

    public void Heal(float healh)
    {
        _actualHealth = Mathf.Clamp(_actualHealth + healh, 0, maxHealth);
    }

    public bool IsAlive()
    {
        return _alive;
    }

    
}
