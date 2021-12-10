using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
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

    void Start()
    {
        _actions = gameObject.GetComponent<IDeadable>();
        _movement = gameObject.GetComponent<IMovil>();
        _alive = true;
        _actualHealth = maxHealth;

        SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.vidaMaxTexto, maxHealth);
        SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.ataqueTexto, strength);
        SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.defensaTexto, armor);
        SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.velocidadTexto, speed);
    }

    public float GetSpeedValue()
    {
        if (speed <= 0.25f)
        {
            SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.velocidadTexto, speed);
            return 0.5f;
        }

        SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.velocidadTexto, speed);
        return (float) Math.Sqrt(speed);
    }

    public float GetActualHealth()
    {
        SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.vidaMaxTexto, maxHealth);
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

    }

    public void Heal(float healh)
    {
        _actualHealth = Mathf.Clamp(_actualHealth + healh, 0, maxHealth);
    }

    
    public void Unequip(int pos)
    {
        equipment[pos].Unequip();
    }

    public void Immobilize(float time)
    {
        _movement.DisableMovement(time);
    }

    public void CambiarTextoStats(TMP_Text textoUI, float stat)
    {
        textoUI.SetText(stat.ToString());
    }
}
