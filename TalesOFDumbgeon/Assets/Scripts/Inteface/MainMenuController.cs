using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject titulo;
    [SerializeField] private GameObject botonJugar;
    [SerializeField] private GameObject botonAjustes;
    [SerializeField] private GameObject botonCreditos;

    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jugar()
    {
        LeanTween.moveLocalY(botonJugar, -550, .25f);
        LeanTween.moveLocalY(botonAjustes, -550, .25f);
        LeanTween.moveLocalY(botonCreditos, -550, .25f);
        LeanTween.moveLocalY(titulo, 550, .25f);

        StartCoroutine(EsperarJugar());
    }

    IEnumerator EsperarJugar()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("IsometricScene");
    }

    public void Creditos()
    {
        LeanTween.moveLocalY(botonJugar, -550, .25f);
        LeanTween.moveLocalY(botonAjustes, -550, .25f);
        LeanTween.moveLocalY(botonCreditos, -550, .25f);

        LeanTween.moveLocalY(titulo, 0, .5f).setDelay(1);
        LeanTween.rotateZ(titulo, -90, .5f).setDelay(1);
        LeanTween.scaleX(titulo, 1.5f, .5f).setDelay(1).setEaseInCubic();
        LeanTween.scaleY(titulo, 1.5f, .5f).setDelay(1).setEaseInCubic();

        StartCoroutine(EsperarCreditos());
    }

    IEnumerator EsperarCreditos()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("CreditsScene");
    }
}
