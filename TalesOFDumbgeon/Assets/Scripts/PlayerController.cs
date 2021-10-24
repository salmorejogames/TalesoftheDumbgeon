using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputControler controles;
    public Rigidbody2D playerController;
    public GameObject ptAtaque;
    public GameObject bala;
    public GameObject zonaAtaque;

    public int vida = 20;
    public Vector2 direccion;
    public bool derecha = true;
    public float speed;
    private GameObject joystick;
    
    
    private float attackDelay;
    [SerializeField] private SpriteRenderer sr;

    private enum ArmaRango {CaC, Distancia};
    private bool controlesEnable = true;
    private int cartaUsada;

    private bool canAtack = true;
    //Variables de Objetos
    private ArmaRango armaRango;
    private string nombreArmaEquipada;
    public int damageArmaActual;


    private void Awake()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick");
        playerController = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
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
    void Update()
    {
        if (controlesEnable)
        {
            direccion = controles.Jugador.Move.ReadValue<Vector2>();
            Moverse(direccion);
        }
        
        
    }

    private void reactiveAtack()
    {
        canAtack = true;
        zonaAtaque.GetComponent<Collider2D>().enabled = false;
        zonaAtaque.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        controlesEnable = true;
    }
    private void FixedUpdate()
    {
       
    }

    private void Moverse(Vector2 direccion)
    {
        playerController.velocity = new Vector3(direccion.x, direccion.y, 0) * speed;

        if (direccion.x > 0)   //derecha
        {
            derecha = true;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (direccion.x < 0)  //izquierda
        {
            derecha = false;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (direccion.y > 0)   //abajp
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (direccion.y < 0)  //arriba
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
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

            playerController.velocity = Vector2.zero;
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
        Debug.Log("colision con " + collision.gameObject.name);
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
