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
        run = Mathf.Clamp(run, 0, 12);
        switch (run)
        {
            case 2:
                run = run + (int)Random.Range(0, 3);
            break;
            case 3: case 4: case 5:
                PlayerPrefs.SetInt("Deaths", 6);
                run = 6;
            break;
            case 7:
                PlayerPrefs.SetInt("Deaths", 8);
                run = 8;
            break;
            case 12:
                gameObject.SetActive(false);
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arma")){
            trigger.UpdatePath(run);
            if(run == 6) { run = 7; }
            trigger.TriggerDialogue();
        }

    }
}
