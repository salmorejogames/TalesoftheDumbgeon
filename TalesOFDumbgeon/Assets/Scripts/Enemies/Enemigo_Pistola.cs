using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using UnityEngine.AI;

public class Enemigo_Pistola : BaseEnemy, IDeadable, IMovil
{
    //IDeadable 
    private SpriteRenderer _spr;
    private IsometricMove _player;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField]
    private DamageNumber DmgPrefab;

    public float velocidad = 5;
    public int armadura = 3;
    public int damage = 1;
    public float vision = 4;
    public float maxDistance = 1f;
    public float stopDistance = 3f;
    public float decisionTime = 3f;
    public float decisionClock = 0f;

    public GameObject personaje;
    public GameObject zonaAtaque;
    public RangedWeapon arma;
    private Weapon armaHolder;

    private Rigidbody2D rb;
    //Bala
    /*public Sprite ammoSprite;
    public float range;
    public float ammoSpeed;
    //*/
    private enum Estado { Wandering, Detected, Attacking };
    private Estado estadoActual = Estado.Wandering;
    private Vector3 nextPos;
    private Vector2 direccion;
    private float distanciaPlayer;
    private float rotacion;
    private RaycastHit2D hit;
    private Collider2D choque;
    //Para controlar cuando puede atacar y si esta atacando
    private bool canAtack = true;
    private float attackDelay;
    private float attackTime;

    public enum tipoEnemigo { Abuesqueleto, Cerebro, Duonde, Palloto, Banana, Pelusa };
    public tipoEnemigo especie;

    private void Awake()
    {
        //IDeadable
        stats = gameObject.GetComponent<CharacterStats>();
        _spr = gameObject.GetComponent<SpriteRenderer>();
        _player = SingletoneGameController.PlayerActions.player;
        agent.updateUpAxis = false;
        agent.speed = stats.GetSpeedValue();
        agent.updateRotation = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        arma = new RangedWeapon();
        armaHolder = zonaAtaque.GetComponent<Weapon>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        personaje = GameObject.FindGameObjectWithTag("Player");
        attackDelay = 1.5f;
        attackTime = 1.5f;
        arma.SetWeaponHolder(armaHolder);
        velocidad = stats.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!SingletoneGameController.PlayerActions.dead)
        {
            distanciaPlayer = Vector2.Distance(transform.position, personaje.transform.position);
            direccion = personaje.transform.position - transform.position;
            rotacion = Mathf.Atan2(direccion.x, direccion.y) * Mathf.Rad2Deg;
            direccion.Normalize();
            armaHolder.SetOrientation(-rotacion + 90);
            armaHolder.UpdatePosition(gameObject.transform.position + (Vector3)IsometricUtils.PolarToCartesian(-(rotacion), 0f));

            DecisionEstado();
            //tiempoParado = startTiempoParado;

            /*tiempoParado -= Time.deltaTime;
            Debug.Log("Restamos tiempo transcurrido");
            rb.velocity = Vector2.zero;*/
        }
    }

    private void DecisionEstado()
    {

        decisionClock += Time.deltaTime;
        attackDelay -= Time.deltaTime;

        if (attackDelay <= 0)
        {
            canAtack = true;
            attackDelay = attackTime;
        }

        if (distanciaPlayer > vision)
            estadoActual = Estado.Wandering;
        else if (distanciaPlayer <= vision && distanciaPlayer > stopDistance)
            estadoActual = Estado.Detected;
        else if (distanciaPlayer <= stopDistance)
            estadoActual = Estado.Attacking;

        //Debug.Log(estadoActual);

        if (decisionClock > decisionTime || distanciaPlayer < vision && personaje != null)
        {            
            switch (estadoActual)
            {
                case Estado.Wandering:
                    Wander();
                    decisionClock = 0;
                    transform.position = Vector2.MoveTowards(transform.position, nextPos, velocidad * Time.deltaTime);
                    break;

                case Estado.Detected:
                    transform.position = Vector2.MoveTowards(transform.position, personaje.transform.position, velocidad * Time.deltaTime);
                    //rb.rotation = -rotacion;
                    break;

                case Estado.Attacking:
                    //rb.rotation = -rotacion;
                    Attack();
                    break;
            }
            decisionClock = 0;
        }

        //transform.position = Vector2.MoveTowards(transform.position, nextPos, velocidad * Time.deltaTime);
    }

    private void Alcanzable()
    {
        transform.position = Vector2.MoveTowards(transform.position, personaje.transform.position, velocidad * Time.deltaTime);
    }

    private void Attack()
    {
        if (canAtack)
        {
            if(especie == tipoEnemigo.Cerebro)
            {
                //arma.Atacar(rayos);
                canAtack = false;
                Debug.Log("Intento generar balas");
                Invoke(nameof(ReactiveAttack), arma.AttackSpeed);
            }
        }
    }

    private void ReactiveAttack()
    {
        //canAtack = true;
        arma.Atacar();

        /*
        zonaAtaque.GetComponent<Collider2D>().isTrigger = false;
        rb.velocity = Vector2.zero;
        canAtack = false;
        nextPos = transform.position;

        GameObject ammo = new GameObject("Ammo");
        SpriteRenderer spriteR = ammo.AddComponent<SpriteRenderer>();
        Bala_Move bala = ammo.AddComponent<Bala_Move>();
        Rigidbody2D _rb = ammo.AddComponent<Rigidbody2D>();

        spriteR.sprite = ammoSprite;
        spriteR.color = Color.red;
        rb.bodyType = RigidbodyType2D.Kinematic;
        bala.parentTag = gameObject.tag;
        bala.holderStrength = damage;
        Collider2D collider2D = ammo.AddComponent<PolygonCollider2D>();
        collider2D.isTrigger = true;

        Transform _transform = zonaAtaque.transform;
        ammo.transform.position = transform.position;
        ammo.transform.rotation = Quaternion.Euler(new Vector3(_transform.rotation.x, _transform.rotation.y, _transform.rotation.z)); ;
        */
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
            //Destroy(gameObject);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nextPos = transform.position;
            stats.DoDamage(arma.Dmg, this.transform.position, stats.element);
        }
        /*else if (collision.gameObject.CompareTag("Colisiones"))
        {
            decisionClock = 5f;
        }*/
        Debug.Log("decision CLock: " + decisionClock);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, vision);
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public void Damage(Vector3 enemy, float cantidad, Elements.Element element)
    {
        audio.Play();
        float multiplier = Elements.GetElementMultiplier(element, stats.element);
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

    public void Move()
    {
        
    }

    public void DisableMovement(float time)
    {
        
    }
}
