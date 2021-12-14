using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemigoBanana : BaseEnemy, IDeadable
{
    //IDeadable 
    private SpriteRenderer _spr;
    private IsometricMove _player;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField]
    private DamageNumber DmgPrefab;

    [SerializeField] private BananaAnimator animator;

    public float velocidad;
    public float vision = 3;
    public float maxDistance = 1f;
    public float stopDistance = 0.5f;
    public float decisionTime = 2f;
    public float decisionClock = 0f;

    public GameObject personaje;

    private Rigidbody2D _rb;
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
        _rb = gameObject.GetComponentInChildren<Rigidbody2D>();
        personaje = GameObject.FindGameObjectWithTag("Player");
        _rb.velocity = Vector2.zero;
        attackDelay = 4;
        velocidad = stats.speed;
        attackTime = 3f;
        BaseArmor casco = new BaseArmor();
        casco.Stats = stats;
        casco.Randomize(1);
        casco.Equip();
        casco.Armor = 0f;
        stats.element = casco.Element;
        animator.ChangeColor(casco.Element);
    }

    // Update is called once per frame
    void Update()
    {

        if (!attaking)
        {
            distanciaPlayer = Vector2.Distance(transform.position, personaje.transform.position);
            direccion = personaje.transform.position - transform.position;
            //rotacion = Mathf.Atan2(direccion.x, direccion.y) * Mathf.Rad2Deg;
            direccion.Normalize();

            DecisionEstado();
            tiempoParado = startTiempoParado;
            //Debug.Log("Entramos en la logica");
        }
        else
        {
            if (tiempoParado <= 0)
            {
                animator.StartAttack();
                if (dashTime <= 0)
                {
                    attaking = false;
                    dashTime = startDashTime;
                    _rb.velocity = Vector2.zero;
                    animator.EndAttack();
                }
                else
                {
                    dashTime -= Time.deltaTime;

                    _rb.velocity = direccion * (velocidad * 3f);
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
            decisionClock = 0;
            switch (estadoActual)
            {
                case Estado.Wandering:
                    Wander();
                    break;

                case Estado.Detected:
                    Alcanzable();
                    //rb.rotation = -rotacion;
                    break;

                case Estado.Attacking:
                    //rb.rotation = -rotacion;
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

    public override void Attack()
    {
        if (canAtack)
        {
            animator.PrepareAttack();
            attaking = true;
            canAtack = false;
        }
    }
    
    


    private void Wander()
    {       
        nextPos = new Vector3(UnityEngine.Random.Range(-maxDistance, maxDistance) + transform.position.x, UnityEngine.Random.Range(-maxDistance, maxDistance) + transform.position.y);
        //Alcanzable();
        //Instantiate(Bala, nextPos, Quaternion.identity);
        Debug.Log("hago un wander: " + nextPos);
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
        DamageNumber dmgN = Instantiate(DmgPrefab, transform.position, Quaternion.identity);
        dmgN.Inicializar(cantidad, transform);
        Vector3 direction = gameObject.transform.position - _player.transform.position;
        direction.Normalize();
        _rb.velocity = direction * 1.5f;
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
