using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputControler controles;
    public CharacterController playerController;
    public GameObject ptAtaque;
    public float speed;
    public GameObject bala;
    public Vector2 direccion;
    public bool derecha = true;
    public bool abajo = true;
    [SerializeField] private SpriteRenderer sr;

    private void Awake()
    {
        playerController = gameObject.GetComponent<CharacterController>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        controles = new InputControler();        
    }

    // Start is called before the first frame update
    void Start()
    {
        //speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        direccion = controles.Jugador.Move.ReadValue<Vector2>();
        Moverse(direccion);
        
    }

    private void FixedUpdate()
    {
        Atacar(controles.Jugador.Atacar.ReadValue<float>(), direccion);

    }

    private void Moverse(Vector2 direccion)
    {
        playerController.Move(new Vector3(direccion.x, direccion.y, 0)* Time.deltaTime * speed);

        if (direccion.x > 0)   //derecha
        {
            if (!derecha)
            {
                giroX();
            }
        }
        else if (direccion.x < 0)  //izquierda
        {
            if (derecha)
            {
                giroX();
            }
        }

        if (direccion.y > 0)   //abajp
        {
            if (!abajo)
            {
                giroY();
            }
        }
        else if (direccion.y < 0)  //arriba
        {
            if (abajo)
            {
                giroY();
            }
        }
    }

    private void Atacar(float atacar, Vector2 direction)
    {
        if (atacar > 0)
        {
            Instantiate(bala, ptAtaque.transform.position, this.transform.rotation);
        }        
    }

    protected void giroX()
    { //girar la imagnen del personaje
        derecha = !derecha;
        gameObject.transform.Rotate(0f, 180f, 0f);
        
    }

    protected void giroY()
    { //girar la imagnen del personaje
        abajo = !abajo;
        gameObject.transform.Rotate(180f, 0f, 0f);

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
