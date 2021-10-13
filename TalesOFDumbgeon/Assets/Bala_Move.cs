using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Move : MonoBehaviour
{
    public float speed = 10;
    [SerializeField] private PlayerController personaje;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rbBullet;
    private GameObject jugador;
    private Vector2 sentido;

    private bool direccion;
    private bool arriba;

    private void Awake()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        personaje = jugador.GetComponent<PlayerController>();
        direccion = personaje.derecha;
        //speed = 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(jugador.transform.rotation.x == (0f))
        {
            sentido = Vector2.right;
        }else if(jugador.transform.rotation.x == (180f))
        {
            sentido = Vector2.left;
        } else if (jugador.transform.rotation.y == (0f))
        {
            sentido = Vector2.up;
        }
        else if (jugador.transform.rotation.y == (180f))
        {
            sentido = Vector2.down;
        }

    }

    private void FixedUpdate()
    {        
        rbBullet.AddForce(sentido * speed);
        Debug.Log(sentido);

    }

}
