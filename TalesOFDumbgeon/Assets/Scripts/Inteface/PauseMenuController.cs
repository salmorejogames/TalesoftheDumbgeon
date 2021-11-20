using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    private InterfaceControls iuInput;

    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject titulo;
    [SerializeField] private GameObject botonVolver;
    [SerializeField] private GameObject botonAjustes;
    [SerializeField] private GameObject botonSalir;
    [SerializeField] private GameObject volumen;
    [SerializeField] private GameObject botonVolverAjustes;

    private void Awake()
    {
        iuInput = new InterfaceControls();
        iuInput.Menupausa.Pausa.performed += ctx => ActivarMenuPausa();
    }

    private void OnEnable()
    {
        iuInput.Menupausa.Enable();
    }

    private void OnDisable()
    {
        iuInput.Menupausa.Disable();
    }

    public void ActivarMenuPausa()
    {
        Time.timeScale = 0f;
        menuPausa.SetActive(true);

        LeanTween.moveLocalY(titulo, 175, 1.5f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.rotateZ(titulo, -2, 1f).setEaseOutCubic().setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonVolver, -400, 1.5f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonVolver, -170, 1.5f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);
        LeanTween.rotateZ(botonVolver, 4, 1f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonAjustes, 0, 1.5f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonAjustes, -130, 1.5f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);
        LeanTween.rotateZ(botonAjustes, 2, 1f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonSalir, 400, 1.5f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonSalir, -180, 1.5f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);
        LeanTween.rotateZ(botonSalir, -6, 1f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);
    }

    public void Volver()
    {
        LeanTween.moveLocalY(botonVolver, -470, .25f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonAjustes, -470, .25f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonSalir, -470, .25f).setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonVolver, 0, .25f).setIgnoreTimeScale(true);
        LeanTween.moveLocalX(botonSalir, 0, .25f).setIgnoreTimeScale(true);

        LeanTween.moveLocalY(titulo, 520, .25f).setIgnoreTimeScale(true);

        StartCoroutine(EsperarVolver());

        menuPausa.SetActive(false);

        Time.timeScale = 1f;
    }

    public void Ajustes()
    {
        AnimacionAjustes();
    }

    public void AnimacionAjustes()
    {
        LeanTween.moveLocalY(botonVolver, -470, 1f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonSalir, -470, 1f).setIgnoreTimeScale(true);
        LeanTween.moveLocalX(botonVolver, 0, 1f).setIgnoreTimeScale(true);
        LeanTween.moveLocalX(botonSalir, 0, 1f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(titulo, 520, 1f).setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonAjustes, 0, .1f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonAjustes, 220, 1f).setEaseOutCubic().setIgnoreTimeScale(true);

        LeanTween.moveLocalX(volumen, 0, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.moveLocalY(volumen, -20, 1f).setEaseOutCubic().setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonVolverAjustes, 0, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonVolverAjustes, -80, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
    }

    public void AnimacionVolver()
    {
        LeanTween.moveLocalX(botonAjustes, 0, .25f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonAjustes, 220, .25f).setIgnoreTimeScale(true);

        LeanTween.moveLocalX(volumen, 0, .25f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(volumen, 220, .25f).setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonVolverAjustes, 0, .25f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonVolverAjustes, 220, .25f).setIgnoreTimeScale(true);
    }

    public void VolverAjustes()
    {
        AnimacionVolverAjustes();
    }

    public void AnimacionVolverAjustes()
    {
        LeanTween.moveLocalY(titulo, 175, 1.5f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.rotateZ(titulo, -2, 1f).setEaseOutCubic().setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonVolver, -400, 1.5f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonVolver, -170, 1.5f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);
        LeanTween.rotateZ(botonVolver, 4, 1f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonAjustes, 0, 1.5f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonAjustes, -130, 1.5f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);
        LeanTween.rotateZ(botonAjustes, 2, 1f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonSalir, 400, 1.5f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonSalir, -180, 1.5f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);
        LeanTween.rotateZ(botonSalir, -6, 1f).setEaseOutCubic().setDelay(.5f).setIgnoreTimeScale(true);

        LeanTween.moveLocalY(volumen, -270, .25f).setIgnoreTimeScale(true);

        LeanTween.moveLocalY(botonVolverAjustes, -270, .25f).setIgnoreTimeScale(true);
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ClickParaEmpezar");
    }

    IEnumerator EsperarVolver()
    {
        yield return new WaitForSeconds(1f);
        menuPausa.SetActive(false);
    }
}
