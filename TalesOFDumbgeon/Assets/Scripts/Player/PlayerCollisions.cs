using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.CompareTag("Escenario"))
        {
            Debug.Log("Cambiando mapa");
            MapManager.Instance.InstantiateMap(1);
        }
    }
}
