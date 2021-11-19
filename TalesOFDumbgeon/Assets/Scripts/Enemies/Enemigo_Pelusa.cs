using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;


public class Enemigo_Pelusa : MonoBehaviour, IDeadable
{
    //IDeadable 
    private SpriteRenderer _spr;
    private IsometricMove _player;
    private CharacterStats _stats;

    //Enemigo 
    public int velocidad = 5;
    public int armadura = 3;
    public int damage = 1;
    public float vision = 3;
    public float maxDistance = 1f;
    public float stopDistance = 0.5f;
    public float decisionClock = 0f;

    public GameObject personaje;
    public GameObject Bala;
    public GameObject zonaAtaque;

    private Rigidbody2D rb;
    private Vector3 nextPos;
    private Vector2 direccion;
    private RaycastHit2D hit;
    private Collider2D choque;
    private float startDelayTime = 5f;
    private float attackDelay;
    private bool attaking = false;

    public enum tipoEnemigo { Abuesqueleto, Cerebro, Duonde, Palloto, Banana, Pelusa};
    public tipoEnemigo especie;

    // Start is called before the first frame update
    void Start()
    {
        //IDeadable
        _stats = gameObject.GetComponent<CharacterStats>();
        _spr = gameObject.GetComponent<SpriteRenderer>();
        _player = SingletoneGameController.PlayerActions.player;

        rb = gameObject.GetComponent<Rigidbody2D>();
        personaje = GameObject.FindGameObjectWithTag("Player");
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
        attackDelay = startDelayTime;

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
        else if (especie == tipoEnemigo.Pelusa)
        {
            velocidad = 0;
            armadura = 1;
            damage = 4;
            vision = 10;
            stopDistance = vision;
        }

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
        Instantiate(Bala, zonaAtaque.transform.position, Quaternion.identity);
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
            nextPos = transform.position;
        }
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
        float multiplier = Elements.GetElementMultiplier(element, _stats.element);
        if (multiplier > 1.1f)
            _spr.color = Color.red;
        else if (multiplier < 0.9f)
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
