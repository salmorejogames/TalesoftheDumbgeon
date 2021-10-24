using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaAtaqueEnemigo : MonoBehaviour
{
    int damage;

    private void Start()
    {
        damage = gameObject.GetComponentInParent<EnemigoController>().damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().takeDamage(damage);
        }
    }


}
