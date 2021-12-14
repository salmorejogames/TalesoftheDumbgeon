using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ExampleEnemyBehaviour : BaseEnemy, IDeadable, IMovil
{   


    private IsometricMove _player;
    
    [SerializeField]
    private DamageNumber dmgPrefab;
    private bool stopped = false;
    [SerializeField] private AbuesqueletoAnimation animator;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Rigidbody2D rb;
    
    private void Awake()
    {
        stats = gameObject.GetComponent<CharacterStats>();
        _player = SingletoneGameController.PlayerActions.player;
        SmashingWeapon baston = new SmashingWeapon();
        baston.SetWeaponHolder(weapon);
        baston.Randomize(1);
        baston.Armor = 0f;
        baston.Dmg = 0f;
        weapon.ChangeWeapon(baston);
        stats.element = baston.Element;
        
    }
    private void Update()
    {
        StasisUpdate();
        if (!SingletoneGameController.PlayerActions.dead)
        {
            if (!stopped)
            {
                UpdateWeaponAngle();
            }        
        }
    }
    public void Dead()
    {
        SingletoneGameController.SoundManager.audioSrc.PlayOneShot(Audio.clip);
        gameObject.SetActive(false);
    }

    public void Damage(Vector3 enemyPos, float cantidad, Elements.Element element)
    {
        
        Audio.pitch = Random.Range(0.5f, 1.5f);
        Audio.Play();
        float multiplier = Elements.GetElementMultiplier(element, stats.element);
        DamageNumber dmgN = Instantiate(dmgPrefab, transform.position, Quaternion.identity);
        dmgN.Inicializar(cantidad, transform);       
        StasisActionUpdate(StasisActions.Damage, cantidad);
        Vector3 direction = _player.transform.position - gameObject.transform.position;
        direction.Normalize();
        rb.AddForce(-direction*3f);
        Color dmgColor;
        if (multiplier>1.1f)
            dmgColor = Color.red;
        else if(multiplier<0.9f)
            dmgColor = Color.cyan;
        else 
            dmgColor = Color.yellow;
        dmgN.number.color = dmgColor;
    }
    
    public void Move()
    {
        throw new NotImplementedException();
    }

    public void DisableMovement(float time)
    {
        throw new NotImplementedException();
    }
    
    public void UpdateWeaponAngle()
    {
        Vector3 dir = _player.transform.position - weapon.gameObject.transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        weapon.SetOrientation(angle);
        animator.UpdateDirection(angle);
    }

    public override void Attack()
    {
        Debug.Log("Bastonazo");
    }
}
