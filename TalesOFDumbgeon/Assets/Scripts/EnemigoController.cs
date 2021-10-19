using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoController : MonoBehaviour
{

    public int velocidad = 5;
    public int armadura = 3;
    public int damage = 1;
    public float vision = 3;

    public GameObject personaje;

    private Rigidbody2D rb;
    private enum Estado { Wandering, Detected, Attacking};
    private Estado estadoActual = Estado.Wandering;
    private Vector2 nextPos = Vector2.zero;
    private float distanciaPlayer;
    public enum tipoEnemigo {Abuesqueleto, Cerebro, Duonde, Palloto};
    public tipoEnemigo especie;
    private NavMeshAgent agente;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        personaje = GameObject.FindGameObjectWithTag("Player");
        agente = GetComponent<NavMeshAgent>();

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
        distanciaPlayer = Vector2.Distance(transform.position, personaje.transform.position);
        agente.updateRotation = false;
        agente.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(transform.position, nextPos, velocidad * Time.deltaTime);

        if (personaje != null && Vector2.Distance(transform.position, nextPos) < vision)
        {
            distanciaPlayer = Vector2.Distance(transform.position, personaje.transform.position);
            if (distanciaPlayer >= 3)
                estadoActual = Estado.Wandering;
            else if (distanciaPlayer <= 3 && distanciaPlayer >= 0.5f)
                estadoActual = Estado.Detected;
            else
                estadoActual = Estado.Attacking;


            switch (estadoActual)
            {
                case Estado.Wandering:
                    Wander();
                    break;

                case Estado.Detected:
                    agente.SetDestination(personaje.transform.position);
                    //transform.LookAt(personaje.transform.position);
                    break;

                case Estado.Attacking:
                    CanAttack();
                    break;
            }            
        }
        
    }

    private void CanAttack()
    {
        Debug.Log("Esta atacando");
    }

    private void Wander()
    {
        nextPos = new Vector2(UnityEngine.Random.Range(-vision, vision), UnityEngine.Random.Range(-vision, vision));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            Debug.Log(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage(int damage)
    {
        armadura -= damage;
    }

}
