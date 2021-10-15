using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Move : MonoBehaviour
{
    public float speed;
    [SerializeField] private PlayerController personaje;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rbBullet;
    private GameObject jugador;
    private Vector2 sentido;
    private Quaternion rotacion;
    private Vector3 rotacion2;

    private bool direccion;
    private bool arriba;

    private void Awake()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        personaje = jugador.GetComponent<PlayerController>();
        speed = 100f;
    }

    // Start is called before the first frame update
    void Start()
    {
        sentido = jugador.transform.right;
        rbBullet.AddForce(sentido * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (!collision.gameObject.CompareTag("Arma"))
        {
            if (collision.gameObject.CompareTag("Enemigo"))
            {
                collision.GetComponent<EnemigoController>().TakeDamage(personaje.damageArmaActual);
            }

            Destroy(gameObject);
        }
    }
}
