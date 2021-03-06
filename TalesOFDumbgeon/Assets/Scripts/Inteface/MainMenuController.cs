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

    [SerializeField] private GameObject botonVolver;

    [SerializeField] private GameObject tutorial1;
    [SerializeField] private GameObject tutorial2;
    [SerializeField] private GameObject tutorial3;
    [SerializeField] private GameObject tutorial4;

    [SerializeField] private GameObject volumen;

    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject menuAjustes;
    [SerializeField] private GameObject menuGuia;

    [SerializeField] private Image tutorial1Imagen;
    [SerializeField] private Image tutorial2Imagen;

    [SerializeField] private Sprite tutorial1Movil;
    [SerializeField] private Sprite tutorial2Movil;

    [SerializeField] private Button jugarBoton;
    [SerializeField] private Button ajustesBoton;
    [SerializeField] private Button guiaBoton;
    [SerializeField] private Button creditosBoton;
    [SerializeField] private Button volverBoton;

    [SerializeField] private Button avanzarBoton1;
    [SerializeField] private Button avanzarBoton2;
    [SerializeField] private Button avanzarBoton3;
    [SerializeField] private Button avanzarBoton4;

    [SerializeField] private Button retrocederBoton1;
    [SerializeField] private Button retrocederBoton2;
    [SerializeField] private Button retrocederBoton3;
    [SerializeField] private Button retrocederBoton4;

    private int pagina = 0;

    private void Start()
    {
        PlayerPrefs.SetInt("Deaths", 0);
        PlayerPrefs.SetInt("Botijos", 0);
        HacerNoInteractuable(jugarBoton);
        HacerNoInteractuable(ajustesBoton);
        HacerNoInteractuable(creditosBoton);
        HacerNoInteractuable(guiaBoton);
        StartCoroutine(MenuPrincipalInteractuable(1.9f));
    }

    public void Jugar()
    {
        LeanTween.moveLocalY(botonJugar, -550, .25f);
        LeanTween.moveLocalY(botonAjustes, -550, .25f);
        LeanTween.moveLocalY(botonCreditos, -550, .25f);
        LeanTween.moveLocalY(botonGuia, -550, .25f);
        LeanTween.moveLocalY(titulo, 550, .25f);

        HacerNoInteractuable(jugarBoton);
        HacerNoInteractuable(ajustesBoton);
        HacerNoInteractuable(creditosBoton);
        HacerNoInteractuable(guiaBoton);

        StartCoroutine(EsperarJugar());
    }

    IEnumerator EsperarJugar()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("IntroductionScene");
    }

    public void Creditos()
    {
        HacerNoInteractuable(jugarBoton);
        HacerNoInteractuable(ajustesBoton);
        HacerNoInteractuable(creditosBoton);
        HacerNoInteractuable(guiaBoton);

        LeanTween.moveLocalY(botonJugar, -550, .25f);
        LeanTween.moveLocalY(botonAjustes, -550, .25f);
        LeanTween.moveLocalY(botonCreditos, -550, .25f);
        LeanTween.moveLocalY(botonGuia, -550, .25f);

        LeanTween.moveLocalY(titulo, 0, .5f).setDelay(1);
        LeanTween.rotateZ(titulo, 0, .5f).setDelay(1);
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
        HacerNoInteractuable(guiaBoton);

        menuGuia.SetActive(true);

        HacerNoInteractuable(jugarBoton);
        HacerNoInteractuable(ajustesBoton);
        HacerNoInteractuable(creditosBoton);

        HacerNoInteractuable(avanzarBoton1);
        HacerNoInteractuable(retrocederBoton1);

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

        StartCoroutine(HacerInteractuableCoroutine(avanzarBoton1, 1.25f));
        StartCoroutine(HacerInteractuableCoroutine(retrocederBoton1, 1.25f));
    }

    public void AvanzarPaginaGuia()
    {
        switch (pagina)
        {
            case 1:
                HacerNoInteractuable(avanzarBoton1);
                HacerNoInteractuable(retrocederBoton1);
                HacerNoInteractuable(avanzarBoton2);
                HacerNoInteractuable(retrocederBoton2);

                LeanTween.moveLocalX(tutorial1, 1260, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial1, 0, 1f).setEaseOutCubic();

                LeanTween.moveLocalX(tutorial2, 0, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial2, 0, 1f).setEaseOutCubic();

                pagina = 2;

                StartCoroutine(HacerInteractuableCoroutine(avanzarBoton2, 1.2f));
                StartCoroutine(HacerInteractuableCoroutine(retrocederBoton2, 1.2f));

                break;

            case 2:
                HacerNoInteractuable(avanzarBoton2);
                HacerNoInteractuable(retrocederBoton2);
                HacerNoInteractuable(avanzarBoton3);
                HacerNoInteractuable(retrocederBoton3);

                LeanTween.moveLocalX(tutorial2, 1260, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial2, 0, 1f).setEaseOutCubic();

                LeanTween.moveLocalX(tutorial3, 0, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial3, 0, 1f).setEaseOutCubic();

                pagina = 3;

                StartCoroutine(HacerInteractuableCoroutine(avanzarBoton3, 1.25f));
                StartCoroutine(HacerInteractuableCoroutine(retrocederBoton3, 1.25f));

                break;

            case 3:
                HacerNoInteractuable(avanzarBoton3);
                HacerNoInteractuable(retrocederBoton3);
                HacerNoInteractuable(avanzarBoton4);
                HacerNoInteractuable(retrocederBoton4);

                LeanTween.moveLocalX(tutorial3, 1260, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial3, 0, 1f).setEaseOutCubic();

                LeanTween.moveLocalX(tutorial4, 0, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial4, 0, 1f).setEaseOutCubic();

                pagina = 4;

                StartCoroutine(HacerInteractuableCoroutine(avanzarBoton4, 1.25f));
                StartCoroutine(HacerInteractuableCoroutine(retrocederBoton4, 1.25f));

                break;

            case 4:
                HacerNoInteractuable(avanzarBoton4);
                HacerNoInteractuable(retrocederBoton4);

                LeanTween.moveLocalX(tutorial4, 1260, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial4, 0, 1f).setEaseOutCubic();

                AnimacionMenuPrincipal();

                StartCoroutine(MenuPrincipalInteractuable(1.9f));

                break;
        }
    }

    public void RetrocederPaginaGuia()
    {
        switch (pagina)
        {
            case 1:
                HacerNoInteractuable(avanzarBoton1);
                HacerNoInteractuable(retrocederBoton1);

                LeanTween.moveLocalX(tutorial1, 1260, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial1, 0, 1f).setEaseOutCubic();

                AnimacionMenuPrincipal();

                StartCoroutine(MenuPrincipalInteractuable(1.9f));

                break;

            case 2:
                HacerNoInteractuable(avanzarBoton1);
                HacerNoInteractuable(retrocederBoton1);
                HacerNoInteractuable(avanzarBoton2);
                HacerNoInteractuable(retrocederBoton2);


                LeanTween.moveLocalX(tutorial1, 0, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial1, 0, 1f).setEaseOutCubic();

                LeanTween.moveLocalX(tutorial2, 1260, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial2, 0, 1f).setEaseOutCubic();

                pagina = 1;

                StartCoroutine(HacerInteractuableCoroutine(avanzarBoton1, 1.25f));
                StartCoroutine(HacerInteractuableCoroutine(retrocederBoton1, 1.25f));

                break;

            case 3:
                HacerNoInteractuable(avanzarBoton2);
                HacerNoInteractuable(retrocederBoton2);
                HacerNoInteractuable(avanzarBoton3);
                HacerNoInteractuable(retrocederBoton3);


                LeanTween.moveLocalX(tutorial2, 0, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial2, 0, 1f).setEaseOutCubic();

                LeanTween.moveLocalX(tutorial3, 1260, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial3, 0, 1f).setEaseOutCubic();

                pagina = 2;

                StartCoroutine(HacerInteractuableCoroutine(avanzarBoton2, 1.25f));
                StartCoroutine(HacerInteractuableCoroutine(retrocederBoton2, 1.25f));

                break;

            case 4:
                HacerNoInteractuable(avanzarBoton3);
                HacerNoInteractuable(retrocederBoton3);
                HacerNoInteractuable(avanzarBoton4);
                HacerNoInteractuable(retrocederBoton4);

                LeanTween.moveLocalX(tutorial3, 0, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial3, 0, 1f).setEaseOutCubic();

                LeanTween.moveLocalX(tutorial4, 1260, 1f).setEaseOutCubic();
                LeanTween.moveLocalY(tutorial4, 0, 1f).setEaseOutCubic();
                
                pagina = 3;

                StartCoroutine(HacerInteractuableCoroutine(avanzarBoton3, 1.25f));
                StartCoroutine(HacerInteractuableCoroutine(retrocederBoton3, 1.25f));

                break;
        }
    }

    public void AnimacionMenuPrincipal()
    {
        LeanTween.moveLocalY(titulo, 190, 1f).setEaseOutCubic();
        LeanTween.rotateZ(titulo, 5, 1f).setEaseOutCubic();

        LeanTween.moveLocalX(botonJugar, -13, 1f).setEaseOutCubic().setDelay(.75f);
        LeanTween.moveLocalY(botonJugar, -120, 1f).setEaseOutCubic().setDelay(.75f);
        LeanTween.rotateZ(botonJugar, -5, .8f).setEaseOutCubic().setDelay(.75f);

        LeanTween.moveLocalX(botonAjustes, -420, 1f).setEaseOutCubic().setDelay(.75f);
        LeanTween.moveLocalY(botonAjustes, -180, 1f).setEaseOutCubic().setDelay(.75f);
        LeanTween.rotateZ(botonAjustes, 15, .8f).setEaseOutCubic().setDelay(.75f);

        LeanTween.moveLocalX(botonCreditos, 385, 1f).setEaseOutCubic().setDelay(.75f);
        LeanTween.moveLocalY(botonCreditos, -160, 1f).setEaseOutCubic().setDelay(.75f);
        LeanTween.rotateZ(botonCreditos, 5, .8f).setEaseOutCubic().setDelay(.75f);

        LeanTween.moveLocalY(botonGuia, -320, 1f).setEaseOutCubic().setDelay(1f);
        LeanTween.rotateZ(botonGuia, 1, .8f).setEaseOutCubic().setDelay(1f);
    }

    public void Ajustes()
    {
        menuAjustes.SetActive(true);

        HacerNoInteractuable(ajustesBoton);
        HacerNoInteractuable(volverBoton);

        StartCoroutine(MenuAjustesInteractuable(1.85f));

        LeanTween.moveLocalY(botonJugar, -550, .25f);
        LeanTween.moveLocalY(botonAjustes, -550, .25f);
        LeanTween.moveLocalY(botonCreditos, -550, .25f);
        LeanTween.moveLocalY(botonGuia, -550, .25f);
        LeanTween.moveLocalY(titulo, 550, .25f);

        LeanTween.moveLocalY(volumen, 80, 1f).setEaseOutCubic().setDelay(.5f);
        LeanTween.moveLocalY(botonVolver, -200, 1f).setEaseOutCubic().setDelay(.75f);
    }

    public void Volver()
    {
        HacerNoInteractuable(volverBoton);

        AnimacionVolver();

        HacerNoInteractuable(jugarBoton);
        HacerNoInteractuable(ajustesBoton);
        HacerNoInteractuable(creditosBoton);
        HacerNoInteractuable(guiaBoton);

        //menuPrincipal.SetActive(true);

        StartCoroutine(MenuPrincipalInteractuable(1.9f));
    }

    public void AnimacionVolver()
    {
        LeanTween.moveLocalY(titulo, 190, 1f).setEaseOutCubic();
        LeanTween.rotateZ(titulo, 5, .8f).setEaseOutCubic();

        LeanTween.moveLocalX(botonJugar, -13, 1f).setEaseOutCubic().setDelay(.75f);
        LeanTween.moveLocalY(botonJugar, -120, 1f).setEaseOutCubic().setDelay(.75f);
        LeanTween.rotateZ(botonJugar, -5, .8f).setEaseOutCubic().setDelay(.75f);

        LeanTween.moveLocalX(botonAjustes, -420, 1f).setEaseOutCubic().setDelay(.75f);
        LeanTween.moveLocalY(botonAjustes, -180, 1f).setEaseOutCubic().setDelay(.75f);
        LeanTween.rotateZ(botonAjustes, 15, .8f).setEaseOutCubic().setDelay(.75f);

        LeanTween.moveLocalX(botonCreditos, 385, 1f).setEaseOutCubic().setDelay(.75f);
        LeanTween.moveLocalY(botonCreditos, -160, 1f).setEaseOutCubic().setDelay(.75f);
        LeanTween.rotateZ(botonCreditos, 5, .8f).setEaseOutCubic().setDelay(.75f);

        LeanTween.moveLocalY(botonGuia, -320, 1f).setEaseOutCubic().setDelay(1f);
        LeanTween.rotateZ(botonGuia, 1, .8f).setEaseOutCubic().setDelay(1f);

        LeanTween.moveLocalY(volumen, -500, .25f);
        LeanTween.moveLocalY(botonVolver, -500, .25f);
    }

    IEnumerator MenuPrincipalInteractuable(float segundos)
    {
        yield return new WaitForSeconds(segundos);

        HacerInteractuable(jugarBoton);
        HacerInteractuable(ajustesBoton);
        HacerInteractuable(creditosBoton);
        HacerInteractuable(guiaBoton);

        menuAjustes.SetActive(false);
    }

    IEnumerator MenuAjustesInteractuable(float segundos)
    {
        yield return new WaitForSeconds(segundos);

        HacerInteractuable(volverBoton);
        //menuPrincipal.SetActive(false);
    }

    IEnumerator HacerInteractuableCoroutine(Button button, float segundos)
    {
        yield return new WaitForSeconds(segundos);
        HacerInteractuable(button);
    }

    public void HacerInteractuable(Button button)
    {
        button.interactable = true;
    }

    public void HacerNoInteractuable(Button button)
    {
        button.interactable = false;
    }
}
