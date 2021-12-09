using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterStats : MonoBehaviour
{

    private const int EquipmentParts = 6;

    public BaseEquipment[] equipment = new BaseEquipment[EquipmentParts];
    public float maxHealth;
    public float armor;
    public float strength;
    public float speed;
    public Elements.Element element;
    

    private IDeadable _actions;
    private IMovil _movement;
    private bool _alive;
    private float _actualHealth;

    public TMP_Text vidaMaxTexto;
    public TMP_Text ataqueTexto;
    public TMP_Text defensaTexto;
    public TMP_Text velocidadTexto;

    void Start()
    {
        _actions = gameObject.GetComponent<IDeadable>();
        _movement = gameObject.GetComponent<IMovil>();
        _alive = true;
        _actualHealth = maxHealth;

        vidaMaxTexto.SetText(_actualHealth.ToString());
        ataqueTexto.SetText(strength.ToString());
        defensaTexto.SetText(armor.ToString());
        velocidadTexto.SetText(speed.ToString());
    }

    public float GetSpeedValue()
    {
        if (speed <= 0.25f)
        {
            velocidadTexto.SetText(speed.ToString());
            return 0.5f;
        }

        velocidadTexto.SetText(speed.ToString());
        return (float) Math.Sqrt(speed);
    }

    public float GetActualHealth()
    {
        vidaMaxTexto.SetText(_actualHealth.ToString());
        return _actualHealth;
    }

    public bool IsAlive()
    {
        return _alive;
    }

    public void DoDamage(float dmg, Vector3 origin, Elements.Element atackElement)
    {
        float totalDmg = IsometricUtils.CalculateDamage(dmg, armor, atackElement, element);
        _actualHealth -= Mathf.Clamp(totalDmg, 0, maxHealth);
        _actions.Damage(origin, totalDmg, atackElement);
        if (_actualHealth <= 0)
        {
            _alive = false;
            _actions.Dead();
        }
        Debug.Log(gameObject.name +": Me han hecho " + (totalDmg) + " de dmg, me quedan " + _actualHealth + " de vida");
    }

    public void ReduceMaxHealth(float cantidad)
    {
        maxHealth -= cantidad;
        _actualHealth -= Mathf.Clamp(cantidad, 0, maxHealth);
        if (_actualHealth <= 0)
        {
            _alive = false;
            _actions.Dead();
        }

        vidaMaxTexto.SetText(_actualHealth.ToString());
    }

    public void Heal(float healh)
    {
        _actualHealth = Mathf.Clamp(_actualHealth + healh, 0, maxHealth);
        vidaMaxTexto.SetText(_actualHealth.ToString());
    }

    
    public void Unequip(int pos)
    {
        equipment[pos].Unequip();
    }

    public void Immobilize(float time)
    {
        _movement.DisableMovement(time);
    }
}
