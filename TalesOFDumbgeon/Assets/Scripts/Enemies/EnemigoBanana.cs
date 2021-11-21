using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoBanana : MonoBehaviour, IDeadable
{
    //IDeadable 
    private SpriteRenderer _spr;
    private IsometricMove _player;
    private CharacterStats _stats;

    [SerializeField] private NavMeshAgent agent;
    public int difficulty;

    [SerializeField]
    private DamageNumber DmgPrefab;


    public int velocidad = 5;
    public int armadura = 3;
    public int damage = 1;
    public float vision = 3;
    public float maxDistance = 1f;
    public float stopDistance = 0.5f;
    public float decisionTime = 2f;
    public float decisionClock = 0f;

    public GameObject personaje;
    public GameObject zonaAtaque;

    private Rigidbody2D rb;
    private enum Estado { Wandering, Detected, Attacking};
    private Estado estadoActual = Estado.Wandering;
    private Vector3 nextPos;
    private Vector2 direccion;
    private float distanciaPlayer;
    private float rotacion;
    private RaycastHit2D hit;
    private Collider2D choque;
    private bool canAtack = true;
    private float attackDelay;
    private float dashTime = 0f;
    private float startDashTime = 0.5f;
    private bool attaking = false;
    private float tiempoParado = 0f;
    private float startTiempoParado = 1f;

    public enum tipoEnemigo {Abuesqueleto, Cerebro, Duonde, Palloto, Banana};
    public tipoEnemigo especie;

    // Start is called before the first frame update
    void Start()
    {
        //IDeadable
        _stats = gameObject.GetComponent<CharacterStats>();
        _spr = gameObject.GetComponent<SpriteRenderer>();
        _player = SingletoneGameController.PlayerActions.player;
        agent.updateUpAxis = false;
        agent.speed = _stats.GetSpeedValue();
        agent.updateRotation = false;

        rb = gameObject.GetComponent<Rigidbody2D>();
        personaje = GameObject.FindGameObjectWithTag("Player");
        rb.velocity = Vector2.zero;
        attackDelay = 2;

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
        else if(especie == tipoEnemigo.Banana)
        {
            velocidad = 2;
            armadura = 2;
            damage = 10;
            vision = 5;
            stopDistance = 5;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (!attaking)
        {
            distanciaPlayer = Vector2.Distance(transform.position, personaje.transform.position);
            direccion = personaje.transform.position - transform.position;
            rotacion = Mathf.Atan2(direccion.x, direccion.y) * Mathf.Rad2Deg;
            direccion.Normalize();

            DecisionEstado();
            tiempoParado = startTiempoParado;
            Debug.Log("Entramos en la logica");
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

                    rb.velocity = direccion * velocidad * 3f;
                }
            }
            else
            {
                tiempoParado -= Time.deltaTime;
            }
        }
    }

    private void DecisionEstado()
    {        

        decisionClock++;
        attackDelay++;

        if (attackDelay >= 200)
        {
            canAtack = true;
            zonaAtaque.GetComponent<Collider2D>().isTrigger = true;
        }

        if (distanciaPlayer > vision)
            estadoActual = Estado.Wandering;
        else if (distanciaPlayer <= vision && distanciaPlayer > stopDistance)
            estadoActual = Estado.Detected;
        else if (distanciaPlayer <= stopDistance)
            estadoActual = Estado.Attacking;

        Debug.Log(estadoActual);

        if (decisionClock > decisionTime || distanciaPlayer < vision && personaje != null)
        {
            decisionClock = 0;
            switch (estadoActual)
            {
                case Estado.Wandering:
                    Wander();
                    break;

                case Estado.Detected:
                    Alcanzable();
                    rb.rotation = -rotacion;
                    break;

                case Estado.Attacking:
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

        //!!!!!!!!!!!!!!!!!!!!!!!!!NO BORRAR, ES CODIGO QUE NO FUNCIONA PERO QUE QUIERO IMPLEMETAR PARA QUE FUNCIONE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        /*hit = Physics2D.Raycast(transform.position, nextPos);
        choque = hit.collider;

        if (choque.gameObject.CompareTag("Player"))
        {
            nextPos = choque.transform.position;
            Debug.Log("Estoy igualando al jugador");
        }
        else
        {
            Vector3 punto = choque.bounds.center;
            Vector3 puntoA = punto + choque.bounds.extents;
            Vector3 puntoB = punto - choque.bounds.extents;
            Vector3 puntoCercano = choque.bounds.ClosestPoint(transform.position);
            Debug.Log("Me meto a recalcular el camino");

            if(transform.position.y != puntoCercano.y)
            {
                if(Vector3.Distance(personaje.transform.position, puntoA) < Vector3.Distance(personaje.transform.position, puntoB)){
                    nextPos = new Vector3(puntoA.x + 0.5f, puntoCercano.y, 0);  
                }else
                {
                    nextPos = new Vector3(puntoB.x + 0.5f, puntoCercano.y, 0);
                }
            }
            else
            {
                if (Vector3.Distance(personaje.transform.position, puntoA) < Vector3.Distance(personaje.transform.position, puntoB))
                {
                    nextPos = new Vector3(puntoCercano.x, puntoA.y + 0.5f, 0);
                }
                else
                {
                    nextPos = new Vector3(puntoCercano.x, puntoB.y + 0.5f, 0);
                }
            }
        }*/
        
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!NO BORRAR, ES CODIGO QUE NO FUNCIONA PERO QUE QUIERO HACER QUE FUNCIONE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }

    private void Attack()
    {
        if (canAtack)
        {
            if (especie == tipoEnemigo.Abuesqueleto)
            {
                zonaAtaque.GetComponent<Collider2D>().isTrigger = false;
                rb.velocity = Vector2.zero;
                canAtack = false;
                nextPos = transform.position;
            }else if(especie == tipoEnemigo.Banana)
            {
                zonaAtaque.GetComponent<Collider2D>().isTrigger = false;
                attaking = true;
            }
        }
    }


    private void Wander()
    {       
        nextPos = new Vector3(UnityEngine.Random.Range(-maxDistance, maxDistance) + transform.position.x, UnityEngine.Random.Range(-maxDistance, maxDistance) + transform.position.y);
        //Alcanzable();
        //Instantiate(Bala, nextPos, Quaternion.identity);
        Debug.Log("hago un wander: " + nextPos);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            Debug.Log(collision.gameObject);
            
        }else if (collision.gameObject.CompareTag("Player"))
        {
            nextPos = transform.position;
            collision.gameObject.GetComponent<CharacterStats>().DoDamage(damage, this.transform.position, _stats.element);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nextPos = transform.position;
            collision.gameObject.GetComponent<CharacterStats>().DoDamage(damage, this.transform.position, _stats.element);
        }/*else if (collision.gameObject.CompareTag("Colisiones"))
        {
            decisionClock = 5f;
        }*/
        Debug.Log("decision CLock: " + decisionClock);
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public void Damage(Vector3 enemyPos, float cantidad, Elements.Element element)
    {
        float multiplier = Elements.GetElementMultiplier(element, _stats.element);
        DamageNumber dmgN = Instantiate(DmgPrefab, transform.position, Quaternion.identity);
        dmgN.Inicializar(cantidad, transform);
        if (multiplier > 1.1f)
            _spr.color = Color.red;
        else if (multiplier < 0.9f)
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
}
