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
    public float maxDistance = 5f;
    public float stopDistance = 0.5f;

    public GameObject personaje;

    private Rigidbody2D rb;
    private enum Estado { Wandering, Detected, Attacking};
    private Estado estadoActual = Estado.Wandering;
    private Vector3 nextPos;
    private Vector2 direccion;
    private float distanciaPlayer;
    private float rotacion;


    public enum tipoEnemigo {Abuesqueleto, Cerebro, Duonde, Palloto};
    public tipoEnemigo especie;
    
    // Start is called before the first frame update
    void Start()
    {
        //nextPos = transform.position * 1.2f;
        rb = gameObject.GetComponent<Rigidbody2D>();
        personaje = GameObject.FindGameObjectWithTag("Player");

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
    }

    // Update is called once per frame
    void Update()
    {
        distanciaPlayer = Vector2.Distance(transform.position, personaje.transform.position);
        direccion = personaje.transform.position - transform.position;
        rotacion = Mathf.Atan2(direccion.x, direccion.y) * Mathf.Rad2Deg;
        direccion.Normalize();

        if (distanciaPlayer > vision)
            estadoActual = Estado.Wandering;
        else if (distanciaPlayer <= vision && distanciaPlayer > stopDistance)
            estadoActual = Estado.Detected;
        else if(distanciaPlayer <= stopDistance)
            estadoActual = Estado.Attacking;
               
        Debug.Log(estadoActual);
        //if (personaje != null && Vector2.Distance(transform.position, nextPos) <= vision && Vector2.Distance(transform.position, personaje.transform.position) <= vision)
        
        if (personaje != null)
        {
            switch (estadoActual)
            {
                case Estado.Wandering:
                    if (Vector2.Distance(transform.position, nextPos) < vision)
                    Wander();
                    break;

                case Estado.Detected:
                    rb.rotation = -rotacion;
                    Debug.Log(distanciaPlayer);
                    break;

                case Estado.Attacking:
                    rb.rotation = -rotacion;
                    Attack();
                    break;
            }
        }

        rb.velocity = direccion * velocidad;
 
    }

    private void Attack()
    {
        rb.velocity = Vector2.zero;
        nextPos = transform.position;
        Debug.Log("Esta atacando");
    }  

    private void Wander()
    {       
        nextPos = new Vector3(UnityEngine.Random.Range(-maxDistance, maxDistance), UnityEngine.Random.Range(-maxDistance, maxDistance));
        direccion = nextPos - transform.position;
        Debug.Log("Nueva posicion " + nextPos);
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
            nextPos = transform.position;
        }else if (collision.gameObject.CompareTag("Colisiones"))
        {
            direccion = -nextPos - transform.position;
        }
        
    }

    public void TakeDamage(int damage)
    {
        armadura -= damage;
    }

}
