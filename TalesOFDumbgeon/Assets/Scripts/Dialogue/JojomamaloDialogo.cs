using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JojomamaloDialogo : MonoBehaviour
{
    public int run = 0;

    public DialogueTrigger trigger;
    

    // Start is called before the first frame update
    void Start()
    {
        run = PlayerPrefs.GetInt("Jojomamalos", 0);
        run = Mathf.Clamp(run, 0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arma")){
            trigger.UpdatePath(run);
            if(run == 6) { run = 7; }
            trigger.TriggerDialogue();
        }

    }
}
