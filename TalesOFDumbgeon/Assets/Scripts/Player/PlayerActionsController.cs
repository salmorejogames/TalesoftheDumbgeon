using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionsController : MonoBehaviour
{
    public InputControler controles;
    public GameObject ptAtaque;
    public GameObject bala;
    public GameObject zonaAtaque;

    public int vida = 20;
    private GameObject joystick;
    private float attackDelay;
    private enum ArmaRango {CaC, Distancia};
    private bool controlesEnable = true;
    private int cartaUsada;

    private bool canAtack = true;
    //Variables de Objetos
    private ArmaRango armaRango;
    private string nombreArmaEquipada;
    public int damageArmaActual;

    private float distance;
    private IsometricMove _isometricMove;

    private void Awake()
    {
        distance = Vector3.Distance(ptAtaque.transform.position, gameObject.transform.position);
        _isometricMove = gameObject.GetComponent<IsometricMove>();
        joystick = GameObject.FindGameObjectWithTag("Joystick");
        controles = new InputControler();
        controles.Jugador.Atacar.performed += ctx => Atacar();
        controles.Jugador.Habilidad1.performed += ctx => usarCarta(1);
        controles.Jugador.Habilidad2.performed += ctx => usarCarta(2);
        controles.Jugador.Habilidad3.performed += ctx => usarCarta(3);
        controles.Jugador.Habilidad4.performed += ctx => usarCarta(4);
    }

    // Start is called before the first frame update
    void Start()
    {
        attackDelay = 2;
        //armaRango = ArmaRango.Distancia;
        armaRango = ArmaRango.CaC;
    }

    // Update is called once per frame
    private void reactiveAtack()
    {
        canAtack = true;
        zonaAtaque.GetComponent<Collider2D>().enabled = false;
        zonaAtaque.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        controlesEnable = true;
    }

    private void Update()
    {
        float angle = _isometricMove.angle;
        Vector3 newCenter = gameObject.transform.position + (Vector3) IsometricUtils.PolarisToCartesian(angle, distance);
        //newCenter = IsometricUtils.CartesianToIsometric(newCenter);
        ptAtaque.gameObject.transform.position = newCenter;
    }

    private void Atacar()
    {
        if (canAtack)
        {
            
            if (armaRango == ArmaRango.Distancia)
            {
                Instantiate(bala, ptAtaque.transform.position, Quaternion.Euler(transform.rotation.eulerAngles));
                Debug.Log("Ataque a distancia");
            }
            else if (armaRango == ArmaRango.CaC)
            {
                zonaAtaque.GetComponent<Collider2D>().enabled = true;
                zonaAtaque.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 241);
                Debug.Log("Ataque cuerpo a cuerpo");
            }
            controlesEnable = false;
            canAtack = false;
            Invoke(nameof(reactiveAtack), attackDelay);
        }        
    }

    public void usarCarta(int hueco)
    {
        Debug.Log("Usaste la carta " + hueco);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("colision con " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            takeDamage(collision.gameObject.GetComponent<EnemigoController>().damage);
        }

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        vida -= damage;
    }
    
    private void OnEnable()
    {
        controles.Enable();
    }

    private void OnDisable()
    {
        controles.Disable();
    }
}
