using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReyBotijoDialogue : MonoBehaviour
{
    public GameObject carta;
    private bool closed;
    public int run = 0;

    public DialogueTrigger trigger;


    private void Start()
    {
        closed = true;
        run = PlayerPrefs.GetInt("Botijos", 0);
        run = Mathf.Clamp(run, 0, 4);
        switch (run)
        {
            case 1:
                PlayerPrefs.SetInt("Botijos", 2);
                run = 2;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arma") || collision.gameObject.CompareTag("Bala"))
        {
            if (closed)
            {
                GameObject newCard = Instantiate(carta, gameObject.transform.position + new Vector3(0.0f, -1.8f, 0.0f), gameObject.transform.rotation);
                newCard.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                trigger.UpdatePath(run);
                PlayerPrefs.SetInt("Botijos", PlayerPrefs.GetInt("Botijos", 0) + 1);
                closed = false;
            }
            else
            {
                trigger.UpdatePath(1);
            }
            trigger.TriggerDialogue();
        }

    }

}


