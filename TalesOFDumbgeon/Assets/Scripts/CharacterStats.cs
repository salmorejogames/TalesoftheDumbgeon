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
        if (gameObject.CompareTag("Player"))
        {
            SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.vidaMaxTexto, maxHealth);
            SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.ataqueTexto, strength);
            SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.defensaTexto, armor);
            SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.velocidadTexto, speed);
        }
    }

    public float GetSpeedValue()
    {
        if (speed <= 0.25f)
        {
            return 0.5f;
        }

        return (float) Math.Sqrt(speed);
    }    

    public float GetActualHealth()
    {
        if (gameObject.CompareTag("Player"))
            SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.vidaMaxTexto, maxHealth);
        return _actualHealth;
    }

    public void SetSpeedValue(float speed)
    {
        this.speed += speed;
        if (gameObject.CompareTag("Player"))
            SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.velocidadTexto, this.speed);
    }

    public void SetArmor(float armor)
    {
        this.armor += armor;
        if (gameObject.CompareTag("Player"))
            SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.defensaTexto, this.armor);
    }

    public void SetStrength(float strength)
    {
        this.strength += strength;
        if (gameObject.CompareTag("Player"))
            SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.ataqueTexto, this.strength);
    }

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth += maxHealth;
        if (gameObject.CompareTag("Player"))
            SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.vidaMaxTexto, this.maxHealth);
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
        if (gameObject.CompareTag("Player"))
            SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.vidaMaxTexto, this.maxHealth);
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
        if (gameObject.CompareTag("Player"))
            SingletoneGameController.InterfaceController.ActualizarStatsUI(SingletoneGameController.InterfaceController.vidaMaxTexto, this.maxHealth);
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
