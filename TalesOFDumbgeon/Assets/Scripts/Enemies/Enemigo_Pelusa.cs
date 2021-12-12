using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using System;
using UnityEngine.AI;
using Random = System.Random;

public class Enemigo_Pelusa : BaseEnemy, IDeadable
{
    //IDeadable 
    private SpriteRenderer _spr;
    private IsometricMove _player;
  


    [SerializeField]
    private DamageNumber DmgPrefab;

    //Enemigo 
    public float vision = 3;
    public float maxDistance = 1f;
    public float stopDistance = 0.5f;
    public float decisionClock = 0f;
    public int maxChilds = 7;

    public GameObject personaje;
    public Pelusa_Peque PelusaPeque;
    public GameObject zonaAtaque;

    private Rigidbody2D rb;
    private Vector2 direccion;
    private float startDelayTime = 2f;
    private float attackDelay;
    
    [SerializeField] private SpriteRenderer bodySprite;
    private void Awake()
    {
        
        //IDeadable
        stats = gameObject.GetComponent<CharacterStats>();
        _spr = gameObject.GetComponent<SpriteRenderer>();
        stats.element = Elements.GetRandomElement();
        bodySprite.color = SingletoneGameController.InfoHolder.LoadColor(stats.element);
        _player = SingletoneGameController.PlayerActions.player;
    }

    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        personaje = GameObject.FindGameObjectWithTag("Player");
        //rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
        attackDelay = startDelayTime;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!SingletoneGameController.PlayerActions.dead)
        {
            if (_player == null)
               // _player = SingletoneGameController.PlayerActions.player;

            direccion = personaje.transform.position - transform.position;
            direccion.Normalize();
            attackDelay -= Time.deltaTime;
            if (attackDelay <= 0)
            {
                Attack();
                attackDelay = startDelayTime;
            }
        }
    }

    private void Attack()
    {
        if (gameObject.transform.childCount <= maxChilds)
        {
            Pelusa_Peque newPelusa =  Instantiate(PelusaPeque, zonaAtaque.transform.position, Quaternion.identity, gameObject.transform);
            newPelusa.stats.element = stats.element;
        }
           
        //Instantiate(Bala, zonaAtaque.transform.position, Quaternion.identity, gameObject.transform);
        //Instantiate(Bala, zonaAtaque.transform.position, Quaternion.identity, gameObject.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            Debug.Log(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //
        }
        //Debug.Log("decision CLock: " + decisionClock);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, vision);
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }

    public void Dead()
    {
        SingletoneGameController.SoundManager.audioSrc.PlayOneShot(Audio.clip);
        gameObject.SetActive(false);
    }

    public void Damage(Vector3 enemy, float cantidad, Elements.Element element)
    {
        Audio.Play();
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
}
