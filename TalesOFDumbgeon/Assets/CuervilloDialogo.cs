using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuervilloDialogo : MonoBehaviour
{
    public int run = 0;

    public DialogueTrigger trigger;
    

    // Start is called before the first frame update
    void Start()
    {
        run = PlayerPrefs.GetInt("Deaths", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arma")){
            trigger.UpdatePath(run);
            trigger.TriggerDialogue();
        }

    }
}
