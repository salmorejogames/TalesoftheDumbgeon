using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TerminarVictory", 72.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TerminarVictory()
    {
        SceneManager.LoadScene("CreditsScene");
    }

}
