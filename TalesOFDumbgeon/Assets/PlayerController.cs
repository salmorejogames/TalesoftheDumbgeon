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

    public int vida = 5;
    public Vector2 direccion;
    public bool derecha = true;
    public float speed;


    private float attackTime;
    private float attackDelay;
    [SerializeField] private SpriteRenderer sr;

    private enum ArmaRango {CaC, Distancia};
    private bool controlesEnable = true;
    private int cartaUsada;

    //Variables de Objetos
    private ArmaRango armaRango;
    private string nombreArmaEquipada;
    public int damageArmaActual;


    private void Awake()
    {
        playerController = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        controles = new InputControler();        
    }

    // Start is called before the first frame update
    void Start()
    {
        attackDelay = 2;
        attackTime = 2;
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

            if (controles.Jugador.Habilidad1.ReadValue<bool>())
            {
                cartaUsada = 1;
            }else if (controles.Jugador.Habilidad2.ReadValue<bool>())
            {
                cartaUsada = 2;
            }
            else if (controles.Jugador.Habilidad3.ReadValue<bool>())
            {
                cartaUsada = 3;
            }
            else if (controles.Jugador.Habilidad4.ReadValue<bool>())
            {
                cartaUsada = 4;
            }else
            {
                cartaUsada = 0;
            }
            usarCarta(cartaUsada);
        }



        if (attackTime < 1)
        {
            zonaAtaque.GetComponent<Collider2D>().isTrigger = true;
            zonaAtaque.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            controlesEnable = true;
        }

        attackTime -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Atacar(controles.Jugador.Atacar.ReadValue<float>());

    }

    private void Moverse(Vector2 direccion)
    {
        playerController.velocity = new Vector3(direccion.x, direccion.y, 0) * speed;

        if (direccion.x > 0)   //derecha
        {
            giroX();
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (direccion.x < 0)  //izquierda
        {
            giroX();
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

    private void Atacar(float atacar)
    {
        if (atacar > 0 && attackTime < 0)
        {
            if (armaRango == ArmaRango.Distancia)
            {
                Instantiate(bala, ptAtaque.transform.position, Quaternion.Euler(transform.rotation.eulerAngles));
                Debug.Log("Ataque a distancia");
            }
            else if (armaRango == ArmaRango.CaC)
            {
                zonaAtaque.GetComponent<Collider2D>().isTrigger = false;
                zonaAtaque.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 241);
                Debug.Log("Ataque cuerpo a cuerpo");
            }
            controlesEnable = false;
            attackTime = attackDelay;
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
            vida -= collision.gameObject.GetComponent<EnemigoController>().damage;
        }

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected void giroX()      //girar el personaje
    { 
        derecha = !derecha;
        //gameObject.transform.Rotate(0f, 180f, 0f);        
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
