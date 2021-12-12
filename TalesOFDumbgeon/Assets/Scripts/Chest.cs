using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject carta;
    public Sprite cofreAbierto;
    private bool closed;
    public AudioSource audio;

    private void Start()
    {
        closed = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Arma") || collision.gameObject.CompareTag("Bala")) && closed)
        {
            GameObject newCard = Instantiate(carta,gameObject.transform.position + new Vector3(1.0f,0.0f,0.0f), gameObject.transform.rotation);
            newCard.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = cofreAbierto;
            audio.Play();
            closed = false;
        }
        
    }




}
