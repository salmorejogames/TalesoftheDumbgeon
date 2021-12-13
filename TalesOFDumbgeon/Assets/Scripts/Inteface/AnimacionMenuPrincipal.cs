using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionMenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject menuPrincipal;

    [SerializeField] private GameObject titulo;
    [SerializeField] private GameObject botonJugar;
    [SerializeField] private GameObject botonAjustes;
    [SerializeField] private GameObject botonCreditos;
    [SerializeField] private GameObject botonGuia;

    //[SerializeField] private AudioClip cartaAudio;
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        menuPrincipal.SetActive(true);

        LeanTween.moveLocalY(titulo, 190, 1f).setEaseOutCubic();
        LeanTween.rotateZ(titulo, 5, .8f).setEaseOutCubic();

        audioSource.PlayDelayed(.75f);

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
}
