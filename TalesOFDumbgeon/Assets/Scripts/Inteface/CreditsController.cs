using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    public GameObject saltarBoton;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("TerminarCreditos", 41.5f);
        LeanTween.moveLocalY(saltarBoton, -240, 1.5f).setEaseOutCubic().setDelay(3f);
        LeanTween.rotateZ(saltarBoton, 2, 1f).setEaseOutCubic().setDelay(3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TerminarCreditos()
    {
        SceneManager.LoadScene("ClickParaEmpezar");
    }

    public void SaltarCreditos()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
