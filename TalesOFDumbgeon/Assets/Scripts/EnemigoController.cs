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
    public float maxDistance = 1f;
    public float stopDistance = 0.5f;
    public float decisionTime = 500f;
    public float decisionClock = 0f;

    public GameObject personaje;
    public GameObject Bala;
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
    private float dashTime;
    private float startDashTime = 2f;
    private bool attaking = false;
    private float tiempoParado;
    private float startTiempoParado = 2;

    public enum tipoEnemigo {Abuesqueleto, Cerebro, Duonde, Palloto, Banana};
    public tipoEnemigo especie;
    
    // Start is called before the first frame update
    void Start()
    {        
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

            if (tiempoParado <= 0)
            {
                Logica();
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

                    rb.velocity = direccion * velocidad * 1.5f;
                }
            }
            else
            {
                tiempoParado -= Time.deltaTime;
            }
        }
    }

    private void Logica()
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

        if (decisionClock > decisionTime || Vector3.Distance(transform.position, personaje.transform.position) < vision && personaje != null)
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
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nextPos = transform.position;
        }else if (collision.gameObject.CompareTag("Colisiones"))
        {
            decisionClock = 500;            
        }
        Debug.Log("decision CLock: " + decisionClock);
    }



    public void TakeDamage(int damage)
    {
        armadura -= damage;
    }

}
