using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{

    public int velocidad = 5;
    public int armadura = 3;
    public int damage = 1;

    public GameObject personaje;

    private Rigidbody2D rb;
    public enum tipoEnemigo {Abuesqueleto, Cerebro, Duonde, Palloto};
    public tipoEnemigo especie;

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
        }
        else if (especie == tipoEnemigo.Cerebro)
        {
            velocidad = 6;
            armadura = 1;
            damage = 10;
        }
        else if (especie == tipoEnemigo.Duonde)
        {
            velocidad = 1;
            armadura = 15;
            damage = 3;
        }
        else if (especie == tipoEnemigo.Palloto)
        {
            velocidad = 15;
            armadura = 2;
            damage = 7;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (personaje != null)
            gameObject.transform.position = Vector3.MoveTowards(transform.position, personaje.transform.position, velocidad * Time.deltaTime);
        else
        {
            gameObject.transform.position = gameObject.transform.position;
            rb.velocity = new Vector2(0f, 0f);
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
