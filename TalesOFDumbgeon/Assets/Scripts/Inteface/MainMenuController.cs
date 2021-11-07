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
        SceneManager.LoadScene("CreditsScene");
    }
}
