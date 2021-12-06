using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject carta;
    public Sprite cofreAbierto;
    private bool closed = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Arma") || collision.gameObject.CompareTag("Bala")) && closed == true)
        {
            GameObject newCard = Instantiate(carta,gameObject.transform.position + new Vector3(1.0f,0.0f,0.0f), gameObject.transform.rotation);
            newCard.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = cofreAbierto;
            closed = false;
        }
        
    }




}
