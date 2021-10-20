using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private int _nextMapa = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Escenario"))
        {
            Debug.Log("Cambiando mapa");
            MapManager.Instance.InstantiateMap(_nextMapa);
            _nextMapa++;
            _nextMapa %=  2;
        }
    }
}
