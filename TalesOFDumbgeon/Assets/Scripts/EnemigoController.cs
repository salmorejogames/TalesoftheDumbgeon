using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{

    public int velocidad = 5;
    public int armadura = 3;
    public int damage = 1;
    public float vision = 10;

    public GameObject personaje;

    private Rigidbody2D rb;
    private enum Estado { Wandering, Detected, Attacking};
    private Estado estadoActual = Estado.Wandering;
    private Vector3 nextPos = Vector3.zero;
    private float distanciaPlayer;
    public enum tipoEnemigo {Abuesqueleto, Cerebro, Duonde, Palloto};
    public tipoEnemigo especie;
    private float tiempoDesplazandose = 0;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        personaje = GameObject.FindGameObjectWithTag("Player");        

        if (especie == tipoEnemigo.Abuesqueleto)
        {
            velocidad = 1;
            armadura = 3;
            damage = 6;
            vision = 10;
        }
        else if (especie == tipoEnemigo.Cerebro)
        {
            velocidad = 6;
            armadura = 1;
            damage = 10;
            vision = 10;
        }
        else if (especie == tipoEnemigo.Duonde)
        {
            velocidad = 1;
            armadura = 15;
            damage = 3;
            vision = 10;
        }
        else if (especie == tipoEnemigo.Palloto)
        {
            velocidad = 15;
            armadura = 2;
            damage = 7;
            vision = 10;
        }
        distanciaPlayer = Vector3.Distance(transform.position, personaje.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (personaje != null && tiempoDesplazandose <= 0)
        {
            distanciaPlayer = Vector3.Distance(transform.position, personaje.transform.position);
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
                    nextPos = Vector3.MoveTowards(transform.position, personaje.transform.position, velocidad * Time.deltaTime);
                    break;

                case Estado.Attacking:
                    CanAttack();
                    break;
            }            
        }

        gameObject.transform.position = Vector3.MoveTowards(transform.position, nextPos, velocidad * Time.deltaTime);
        tiempoDesplazandose -= Time.deltaTime;
    }

    private void CanAttack()
    {
        Debug.Log("Esta atacando");
    }

    private void Wander()
    {
        tiempoDesplazandose = 5;
        Vector3 randPos = Vector3.zero;
        int dir = UnityEngine.Random.Range(1, 5);
        if(dir == 1)
        {            
            nextPos = new Vector3(transform.position.x, transform.position.y + 100, transform.position.z);
        }
        else if (dir == 2)
        {
            nextPos = new Vector3(transform.position.x, transform.position.y - 100, transform.position.z);
        }
        else if(dir == 3)
        {
            nextPos = new Vector3(transform.position.x + 100, transform.position.y, transform.position.z);
        }
        else if (dir == 4)
        {
            nextPos = new Vector3(transform.position.x - 100, transform.position.y, transform.position.z);
        }
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
            rb.velocity = Vector3.zero;
        }
    }

    public void TakeDamage(int damage)
    {
        armadura -= damage;
    }

}
