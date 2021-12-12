using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrancisDialogo : MonoBehaviour
{

    public DialogueTrigger trigger;
    public Animator blackIn;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("EmpezarFrase", 1.5f);
    }

    private void EmpezarFrase()
    {
        trigger.CinematicTriggerDialogue();
    }

    public void ResetSkip()
    {
        PlayerPrefs.SetInt("FirstTime", 0);
    }

    public void ActivateCinemaManager()
    {
        if(blackIn != null) { blackIn.SetTrigger("BlackActivate"); }
        Invoke("StartIsometricScene", 2.0f);
    }

    public void StartIsometricScene()
    {
        SceneManager.LoadScene("IsometricScene");
    }

}
