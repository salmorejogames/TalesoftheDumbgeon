using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Enemigo : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    Vector2 posicion;
    Vector2 moveDir;
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        posicion = target.transform.position;
        moveDir = (target.transform.position - transform.position);
        parent = gameObject.GetComponentInParent<GameObject>();
    }

    private void Update()
    {
        bulletRB.AddForce(moveDir * Time.deltaTime * speed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Escenario"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterStats>().DoDamage(5, gameObject, Elements.Element.Caos);
        }
    }
}
