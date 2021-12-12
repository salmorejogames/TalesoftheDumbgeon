using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

public class ExampleEnemyBehaviour : BaseEnemy, IDeadable, IMovil
{   

    private SpriteRenderer _spr;
    private IsometricMove _player;
    [SerializeField] private NavMeshAgent agent;

    [SerializeField]
    private DamageNumber dmgPrefab;
    private float _distanciaPlayer;
    //Para que se pare despues de atacar
    private float stoppedTime;
    private float stoppedDelay;
    private bool stopped = false;
    private bool hit = false;
    private float hitTime = 0.5f;
    private float attackTime;
    [SerializeField] private AbuesqueletoAnimation animator;
    [SerializeField] private Weapon weapon;
    
    private void Awake()
    {
        stats = gameObject.GetComponent<CharacterStats>();
        _spr = gameObject.GetComponent<SpriteRenderer>();
        _player = SingletoneGameController.PlayerActions.player;
        rangoVision = 0f;
        agent.updateUpAxis = false;
        agent.speed = stats.GetSpeedValue();
        agent.updateRotation = false;
        stoppedTime = 4f;
        stoppedDelay = 4f;
        attackTime = 3f;
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
        if (!SingletoneGameController.PlayerActions.dead)
        {
            if (!stopped)
            {
                UpdateWeaponAngle();
                _distanciaPlayer = Vector2.Distance(transform.position, _player.transform.position);
                //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _player.transform.position, stats.GetSpeedValue()*Time.deltaTime);
                if (!hit)
                {
                    if (_distanciaPlayer >= rangoVision)
                    {
                        agent.destination = _player.transform.position;
                    }
                    else
                    {
                        agent.destination = gameObject.transform.position;
                        animator.SetMoving(false);
                        stopped = true;
                    }
                }
                else
                {
                    hitTime -= Time.deltaTime;
                    if(hitTime <= 0)
                    {
                        hit = false;
                        hitTime = 0.5f;
                    }
                }
            }
            else
            {
                agent.destination = gameObject.transform.position;
                stoppedTime += Time.deltaTime;
                if(stoppedTime >= stoppedDelay)
                {
                    stopped = false;
                    animator.SetMoving(true);
                }
            }        
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Bala"))
        {
            //Debug.Log(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterStats>().DoDamage(stats.strength, this.transform.position, stats.element);
            attackTime = 3f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (attackTime <= 0)
            {
                collision.gameObject.GetComponent<CharacterStats>().DoDamage(stats.strength, this.transform.position, stats.element);
                attackTime = 3f;
            }
            else
            {
                //Debug.Log(attackTime);
                attackTime -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterStats>().DoDamage(stats.strength, this.transform.position, stats.element);
        }/*else if (collision.gameObject.CompareTag("Colisiones"))
        {
            decisionClock = 5f;
        }*/
    }

    public void Dead()
    {
        SingletoneGameController.SoundManager.audioSrc.PlayOneShot(Audio.clip);
        gameObject.SetActive(false);
    }

    public void Damage(Vector3 enemyPos, float cantidad, Elements.Element element)
    {

        Audio.Play();
        float multiplier = Elements.GetElementMultiplier(element, stats.element);
        DamageNumber dmgN = Instantiate(dmgPrefab, transform.position, Quaternion.identity);
        dmgN.Inicializar(cantidad, transform);       
        Vector3 direction = _player.transform.position - gameObject.transform.position;
        direction.Normalize();
        agent.destination = -direction;
        hit = true;
        if (multiplier>1.1f)
            _spr.color = Color.red;
        else if(multiplier<0.9f)
            _spr.color = Color.cyan;
        else 
            _spr.color = Color.yellow;
        dmgN.number.color = _spr.color;
        Invoke(nameof(RevertColor), 0.2f);
    }

    public void RevertColor()
    {
        _spr.color = Color.white;
    }

    public int GetDifficulty()
    {
        return difficulty;
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
}
