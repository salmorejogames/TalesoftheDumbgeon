using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject carta;
    public Sprite cofreAbierto;
    public int a;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arma"))
        {
            if(a == 0)
            {
                Instantiate(carta,gameObject.transform.position + new Vector3(1f,0f,0f));
                a++;
                gameObject.GetComponent<SpriteRenderer>().sprite = cofreAbierto;
            }


        }
        
    }


}
