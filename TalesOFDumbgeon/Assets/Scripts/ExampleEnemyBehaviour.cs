using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEditor.UIElements;
using UnityEngine;

public class ExampleEnemyBehaviour : MonoBehaviour
{
    private SpriteRenderer _spr;
    private IsometricMove _player;
    private CharacterStats _stats;
    public GameObject personaje;
    //public GameObject zonaAtaque;
    private Rigidbody2D rb;

    public int velocidad;
    public int armadura;
    public int damage;
    public float vision;
    public float maxDistance;
    public float stopDistance;
    public float decisionTime = 5f;
    public float decisionClock = 0f;
    public enum EstadoBase { Wandering, Detected, Attacking };
    public EstadoBase estadoActual = EstadoBase.Wandering;
    public enum EstadosAttack { Wait, Attack};
    public EstadosAttack _estadosAttack;
    public enum tipoEnemigo { Abuesqueleto, Cerebro, Duonde, Palloto, Banana };
    public tipoEnemigo especie;

    private Vector3 nextPos;
    private Vector2 direccion;
    private float distanciaPlayer;
    private float rotacion;
    private bool canAtack = true;
    private float attackDelay;
    private float dashTime;
    private float startDashTime = 2f;
    public bool attaking = false;
    private float tiempoParado;
    private float startTiempoParado = 2;
    

    private void Start()
    {
        _stats = gameObject.GetComponent<CharacterStats>();
        _spr = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        personaje = GameObject.FindGameObjectWithTag("Player");
        rb.velocity = Vector2.zero;
        attackDelay = 2;
        //_player = SingletoneGameController.PlayerActions.player;

        rb.velocity = Vector2.zero;

        if (especie == tipoEnemigo.Abuesqueleto)
        {
            velocidad = 1;
            armadura = 3;
            damage = 6;
            vision = 3;
        }
        else if (especie == tipoEnemigo.Cerebro)
        {
            velocidad = 6;
            armadura = 1;
            damage = 10;
            vision = 3;
        }
        else if (especie == tipoEnemigo.Duonde)
        {
            velocidad = 1;
            armadura = 15;
            damage = 3;
            vision = 3;
        }
        else if (especie == tipoEnemigo.Palloto)
        {
            velocidad = 15;
            armadura = 2;
            damage = 7;
            vision = 3;
        }
        else if (especie == tipoEnemigo.Banana)
        {
            velocidad = 2;
            armadura = 2;
            damage = 10;
            vision = 5;
            stopDistance = 5;
        }

        //DecisionEstados();
    }

    private void Update()
    {
        if (/*!SingletoneGameController.PlayerActions.dead*/true)
        {
            if(_player==null)
                //_player = SingletoneGameController.PlayerActions.player;

                if (!attaking)
                {
                    distanciaPlayer = Vector2.Distance(transform.position, personaje.transform.position);
                    direccion = personaje.transform.position - transform.position;
                    rotacion = Mathf.Atan2(direccion.x, direccion.y) * Mathf.Rad2Deg;
                    direccion.Normalize();

                    if (tiempoParado <= 0)
                    {
                        DecisionEstados();
                        tiempoParado = startTiempoParado;
                        Debug.Log("Entramos en la logica");
                    }
                    else
                    {
                        tiempoParado -= Time.deltaTime;
                        Debug.Log("Restamos tiempo transcurrido");
                        rb.velocity = Vector2.zero;
                    }
                }
                else
                {
                    if (tiempoParado <= 0)
                    {
                        if (dashTime <= 0)
                        {
                            attaking = false;
                            dashTime = startDashTime;
                            rb.velocity = Vector2.zero;
                        }
                        else
                        {
                            dashTime -= Time.deltaTime;

                            rb.velocity = direccion * velocidad * 2f;
                        }
                    }
                    else
                    {
                        tiempoParado -= Time.deltaTime;
                    }
                }
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _player.transform.position, _stats.speed*Time.deltaTime);
        }
    }

    private void DecisionEstados()
    {

        decisionClock++;
        attackDelay++;

        if (attackDelay >= 200)
        {
            canAtack = true;
            //zonaAtaque.GetComponent<Collider2D>().isTrigger = true;
        }

        if (distanciaPlayer > vision)
            estadoActual = EstadoBase.Wandering;
        else if (distanciaPlayer <= vision && distanciaPlayer > stopDistance)
            estadoActual = EstadoBase.Detected;
        else if (distanciaPlayer <= stopDistance)
            estadoActual = EstadoBase.Attacking;

        Debug.Log(estadoActual);

        if (decisionClock > decisionTime || distanciaPlayer < vision && personaje != null)
        {
            decisionClock = 0;
            switch (estadoActual)
            {
                case EstadoBase.Wandering:
                    Wander();
                    break;

                case EstadoBase.Detected:
                    Alcanzable();
                    rb.rotation = -rotacion;
                    break;

                case EstadoBase.Attacking:
                    rb.rotation = -rotacion;
                    Attack();
                    break;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, velocidad * Time.deltaTime);
    }

    private void Alcanzable()
    {
        nextPos = personaje.transform.position;
    }

    private void Wander()
    {
        nextPos = new Vector3(UnityEngine.Random.Range(-maxDistance, maxDistance) + transform.position.x, UnityEngine.Random.Range(-maxDistance, maxDistance) + transform.position.y);
        //Alcanzable();
        //Instantiate(Bala, nextPos, Quaternion.identity);
        //Debug.Log("hago un wander");
    }

    private void Attack()
    {
        if (canAtack)
        {
            if (especie == tipoEnemigo.Abuesqueleto)
            {
                //zonaAtaque.GetComponent<Collider2D>().isTrigger = false;
                rb.velocity = Vector2.zero;
                canAtack = false;
                nextPos = transform.position;
            }
            else if (especie == tipoEnemigo.Banana)
            {
                //zonaAtaque.GetComponent<Collider2D>().isTrigger = false;
                attaking = true;
            }
        }
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public void Damage(GameObject enemy, float cantidad, Elements.Element element)
    {
        float multiplier = Elements.GetElementMultiplier(element, _stats.element);
        if(multiplier>1.1f)
            _spr.color = Color.red;
        else if(multiplier<0.9f)
            _spr.color = Color.cyan;
        else 
            _spr.color = Color.yellow;
        Invoke(nameof(RevertColor), 0.2f);
    }

    public void RevertColor()
    {
        _spr.color = Color.white;
    }
}
