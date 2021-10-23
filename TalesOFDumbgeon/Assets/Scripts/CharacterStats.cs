using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Equipment;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    private const int EquipmentParts = 6;
    public EquipmentSo[] equipment = new EquipmentSo[EquipmentParts];
    public float maxHealth;
    public float armor;
    public float strength;
    public Elements.Element element;
    public float speed;

    private IDeadable _actions;
    private bool _alive;
    private float _actualHealth;
   
    void Start()
    {
        _actions = gameObject.GetComponent<IDeadable>();
        _alive = true;
        _actualHealth = maxHealth;
    }

    public void DoDamage(float dmg, GameObject origin)
    {
        _actualHealth -= Mathf.Clamp(dmg-armor, 0, maxHealth);
        _actions.Damage(origin, dmg-armor);
        if (_actualHealth <= 0)
            _alive = false;
        Debug.Log(gameObject.name +": Me han hecho " + (dmg-armor) + " de dmg, me quedan " + _actualHealth + " de vida");
        if (!_alive)
        {
            _actions.Dead();
        }
    }

    public void Heal(float healh)
    {
        _actualHealth = Mathf.Clamp(_actualHealth + healh, 0, maxHealth);
    }

    public bool IsAlive()
    {
        return _alive;
    }

    public void Unequip(int pos)
    {
        equipment[pos].Unequip(this);
    }

    public void ReduceMaxHealth(float cantidad)
    {
        maxHealth -= cantidad;
        _actualHealth -= Mathf.Clamp(cantidad, 0, maxHealth);
        if (_actualHealth <= 0)
            _alive = false;
        if (!_alive)
        {
            gameObject.GetComponent<IDeadable>().Dead();
        }
    }
    
}
