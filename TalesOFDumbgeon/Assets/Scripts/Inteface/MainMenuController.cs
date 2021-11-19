using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject titulo;
    [SerializeField] private GameObject botonJugar;
    [SerializeField] private GameObject botonAjustes;
    [SerializeField] private GameObject botonCreditos;
    [SerializeField] private GameObject botonGuia;
    [SerializeField] private GameObject tutorial1;
    [SerializeField] private GameObject tutorial2;

    [SerializeField] private Image tutorial1Imagen;
    [SerializeField] private Image tutorial2Imagen;

    [SerializeField] private Sprite tutorial1Movil;
    [SerializeField] private Sprite tutorial2Movil;

    private int pagina = 0;

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
        LeanTween.moveLocalY(botonGuia, -550, .25f);
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
        LeanTween.moveLocalY(botonGuia, -550, .25f);

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

    public void Tutorial()
    {
        if (CheckIfMobile.isMobile())
        {
            tutorial1Imagen.sprite = tutorial1Movil;
            tutorial2Imagen.sprite = tutorial2Movil;

        }

        LeanTween.moveLocalY(botonJugar, -550, .25f);
        LeanTween.moveLocalY(botonAjustes, -550, .25f);
        LeanTween.moveLocalY(botonCreditos, -550, .25f);
        LeanTween.moveLocalY(botonGuia, -550, .25f);
        LeanTween.moveLocalY(titulo, 550, .25f);

        pagina = 1;

        LeanTween.moveLocalX(tutorial1, 0, 1f).setEaseOutCubic();
        LeanTween.moveLocalY(tutorial1, 0, 1f).setEaseOutCubic();
    }

    public void AvanzarPaginaGuia()
    {
        switch (pagina)
        {
            case 1:
                pagina = 2;
                LeanTween.moveLocalX(tutorial1, 1260, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial1, 0, 1f).setEaseOutCubic();

                LeanTween.moveLocalX(tutorial2, 0, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial2, 0, 1f).setEaseOutCubic();

                break;

            case 2:
                LeanTween.moveLocalX(tutorial2, 1260, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial2, 0, 1f).setEaseOutCubic();

                AnimacionMenuPrincipal();

                break;
        }
    }

    public void RetrocederPaginaGuia()
    {
        switch (pagina)
        {
            case 1:
                LeanTween.moveLocalX(tutorial1, 1260, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial1, 0, 1f).setEaseOutCubic();

                AnimacionMenuPrincipal();

                break;

            case 2:
                pagina = 1;

                LeanTween.moveLocalX(tutorial1, 0, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial1, 0, 1f).setEaseOutCubic();

                LeanTween.moveLocalX(tutorial2, 1260, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial2, 0, 1f).setEaseOutCubic();

                break;
        }
    }

    public void AnimacionMenuPrincipal()
    {
        LeanTween.moveLocalY(titulo, 190, 1.5f).setEaseOutCubic();
        LeanTween.rotateZ(titulo, -85, 1f).setEaseOutCubic();

        LeanTween.moveLocalX(botonJugar, -13, 1.5f).setEaseOutCubic().setDelay(.5f);
        LeanTween.moveLocalY(botonJugar, -120, 1.5f).setEaseOutCubic().setDelay(.5f);
        LeanTween.rotateZ(botonJugar, -5, 1f).setEaseOutCubic().setDelay(.5f);

        LeanTween.moveLocalX(botonAjustes, -420, 1.5f).setEaseOutCubic().setDelay(.5f);
        LeanTween.moveLocalY(botonAjustes, -180, 1.5f).setEaseOutCubic().setDelay(.5f);
        LeanTween.rotateZ(botonAjustes, 15, 1f).setEaseOutCubic().setDelay(.5f);

        LeanTween.moveLocalX(botonCreditos, 385, 1.5f).setEaseOutCubic().setDelay(.5f);
        LeanTween.moveLocalY(botonCreditos, -160, 1.5f).setEaseOutCubic().setDelay(.5f);
        LeanTween.rotateZ(botonCreditos, 5, 1f).setEaseOutCubic().setDelay(.5f);

        LeanTween.moveLocalY(botonGuia, -320, 1.5f).setEaseOutCubic().setDelay(1f);
        LeanTween.rotateZ(botonGuia, 1, 1f).setEaseOutCubic().setDelay(1f);
    }
}
