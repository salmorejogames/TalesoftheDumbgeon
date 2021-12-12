using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vasija : MonoBehaviour
{
    
    public Sprite vasijarota;
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
           
            gameObject.GetComponent<SpriteRenderer>().sprite = vasijarota;
            audio.Play();
            closed = false;
        }

    }
}
