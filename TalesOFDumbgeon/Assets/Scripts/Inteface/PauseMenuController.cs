using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PauseMenuController : MonoBehaviour
{
    private InterfaceControls iuInput;

    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuAjustes;

    [SerializeField] private GameObject titulo;
    [SerializeField] private GameObject botonVolver;
    [SerializeField] private GameObject botonAjustes;
    [SerializeField] private GameObject botonSalir;
    [SerializeField] private GameObject volumen;
    [SerializeField] private GameObject botonVolverAjustes;

    [SerializeField] private Button ajustesBoton;
    [SerializeField] private Button volverBoton;
    [SerializeField] private Button salirBoton;
    [SerializeField] private Button volverAjustesBoton;

    public Volume volume;
    private Vignette vignette;
    private DepthOfField depthOfField;

    private void Awake()
    {
        iuInput = new InterfaceControls();
        iuInput.Menupausa.Pausa.performed += ctx => ActivarMenuPausa();
    }
    private void Start()
    {
        //greyscalePostP.profile.TryGetSettings(out colorGrading);
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out depthOfField);
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
        OnDisable();

        if (SingletoneGameController.PlayerActions.dead)
            return;
        Time.timeScale = 0f;

        //vignette.intensity.value = .5f;
        depthOfField.mode.value = DepthOfFieldMode.Gaussian;
        StartCoroutine(VignettePausa());

        menuPausa.SetActive(true);

        HacerNoInteractuable(ajustesBoton);
        HacerNoInteractuable(volverBoton);
        HacerNoInteractuable(salirBoton);
        HacerNoInteractuable(volverAjustesBoton);

        LeanTween.moveLocalY(titulo, 175, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.rotateZ(titulo, -2, .8f).setEaseOutCubic().setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonVolver, -400, 1f).setEaseOutCubic().setDelay(.75f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonVolver, -170, 1f).setEaseOutCubic().setDelay(.75f).setIgnoreTimeScale(true);
        LeanTween.rotateZ(botonVolver, 4, .8f).setEaseOutCubic().setDelay(.75f).setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonAjustes, 0, 1f).setEaseOutCubic().setDelay(.75f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonAjustes, -130, 1f).setEaseOutCubic().setDelay(.75f).setIgnoreTimeScale(true);
        LeanTween.rotateZ(botonAjustes, 2, .8f).setEaseOutCubic().setDelay(.75f).setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonSalir, 400, 1f).setEaseOutCubic().setDelay(.75f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonSalir, -180, 1f).setEaseOutCubic().setDelay(.75f).setIgnoreTimeScale(true);
        LeanTween.rotateZ(botonSalir, -6, .8f).setEaseOutCubic().setDelay(.75f).setIgnoreTimeScale(true);

        StartCoroutine(MenuPausaInteractuable(1.9f));
    }

    public void Volver()
    {
        HacerNoInteractuable(ajustesBoton);
        HacerNoInteractuable(volverBoton);
        HacerNoInteractuable(salirBoton);
        HacerNoInteractuable(volverAjustesBoton);

        LeanTween.moveLocalY(botonVolver, -470, .25f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonAjustes, -470, .25f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonSalir, -470, .25f).setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonVolver, 0, .25f).setIgnoreTimeScale(true);
        LeanTween.moveLocalX(botonSalir, 0, .25f).setIgnoreTimeScale(true);

        LeanTween.moveLocalY(titulo, 520, .25f).setIgnoreTimeScale(true);

        StartCoroutine(VignetteReanudar());
        StartCoroutine(EsperarVolver());

        depthOfField.mode.value = DepthOfFieldMode.Off;
    }

    public void Ajustes()
    {
        menuAjustes.SetActive(true);

        HacerNoInteractuable(ajustesBoton);
        HacerNoInteractuable(volverBoton);
        HacerNoInteractuable(salirBoton);
        HacerNoInteractuable(volverAjustesBoton);

        AnimacionAjustes();

        StartCoroutine(HacerInteractuableCoroutine(volverAjustesBoton, 1.1f));
    }

    public void AnimacionAjustes()
    {
        LeanTween.moveLocalY(botonVolver, -470, 1f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonAjustes, -470, 1f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonSalir, -470, 1f).setIgnoreTimeScale(true);
        LeanTween.moveLocalX(botonVolver, 0, 1f).setIgnoreTimeScale(true);
        LeanTween.moveLocalX(botonSalir, 0, 1f).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(titulo, 520, 1f).setIgnoreTimeScale(true);

        LeanTween.moveLocalX(volumen, 0, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.moveLocalY(volumen, 40, 1f).setEaseOutCubic().setIgnoreTimeScale(true);

        LeanTween.moveLocalX(botonVolverAjustes, 0, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.moveLocalY(botonVolverAjustes, -130, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
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
        HacerNoInteractuable(ajustesBoton);
        HacerNoInteractuable(volverBoton);
        HacerNoInteractuable(salirBoton);
        HacerNoInteractuable(volverAjustesBoton);

        AnimacionVolverAjustes();

        StartCoroutine(MenuPausaInteractuable(1.9f));

        menuAjustes.SetActive(false);
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
        HacerNoInteractuable(ajustesBoton);
        HacerNoInteractuable(volverBoton);
        HacerNoInteractuable(salirBoton);
        HacerNoInteractuable(volverAjustesBoton);

        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    IEnumerator EsperarVolver()
    {
        yield return new WaitForSecondsRealtime(1f);
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        OnEnable();
    }

    IEnumerator MenuPausaInteractuable(float segundos)
    {
        yield return new WaitForSecondsRealtime(segundos);

        HacerInteractuable(volverBoton);
        HacerInteractuable(ajustesBoton);
        HacerInteractuable(salirBoton);
    }

    IEnumerator HacerInteractuableCoroutine(Button button, float segundos)
    {
        yield return new WaitForSecondsRealtime(segundos);
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

    IEnumerator VignettePausa()
    {
        while (vignette.intensity.value < .60f && depthOfField.gaussianMaxRadius.value < 1.5f)
        {
            vignette.intensity.value += .05f;
            depthOfField.gaussianMaxRadius.value += .005f;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);
    }

    IEnumerator VignetteReanudar()
    {
        while (vignette.intensity.value > 0f || depthOfField.gaussianMaxRadius.value > .5f)
        {
            depthOfField.gaussianMaxRadius.value -= .05f;
            vignette.intensity.value -= .005f;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);
    }
}
