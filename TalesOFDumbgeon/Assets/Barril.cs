using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    public GameObject carta;
    public Sprite barrilRoto;
    private float chance = 0.78f;
    public AudioSource audio;
    private bool closed;
    


    private void Start()
    {
        closed = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Arma") || collision.gameObject.CompareTag("Bala")) && closed)
        {
           

            if (Random.value>= chance)
            {
                GameObject newCard = Instantiate(carta, gameObject.transform.position + new Vector3(1.0f, 0.0f, 0.0f), gameObject.transform.rotation);
                newCard.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            audio.Play();
            gameObject.GetComponent<SpriteRenderer>().sprite = barrilRoto;
            gameObject.tag = "Untagged";
            closed = false;
        }

    }
}
