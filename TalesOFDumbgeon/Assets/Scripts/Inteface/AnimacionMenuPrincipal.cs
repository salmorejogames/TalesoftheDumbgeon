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

        LeanTween.moveLocalY(titulo, 190, 1.5f).setEaseOutCubic();
        LeanTween.rotateZ(titulo, -85, 1f).setEaseOutCubic();

        //audioSource.volume = .5f;
        //audioSource.PlayOneShot(cartaAudio);
        //audioSource.Play();
        audioSource.PlayDelayed(1.5f);

        LeanTween.moveLocalX(botonJugar, -13, 1.5f).setEaseOutCubic().setDelay(1.5f);
        LeanTween.moveLocalY(botonJugar, -120, 1.5f).setEaseOutCubic().setDelay(1.5f);
        LeanTween.rotateZ(botonJugar, -5, 1f).setEaseOutCubic().setDelay(1.5f);

        //audioSource.PlayOneShot(cartaAudio);

        LeanTween.moveLocalX(botonAjustes, -420, 1.5f).setEaseOutCubic().setDelay(1.5f);
        LeanTween.moveLocalY(botonAjustes, -180, 1.5f).setEaseOutCubic().setDelay(1.5f);
        LeanTween.rotateZ(botonAjustes, 15, 1f).setEaseOutCubic().setDelay(1.5f);

        //audioSource.PlayOneShot(cartaAudio);

        LeanTween.moveLocalX(botonCreditos, 385, 1.5f).setEaseOutCubic().setDelay(1.5f);
        LeanTween.moveLocalY(botonCreditos, -160, 1.5f).setEaseOutCubic().setDelay(1.5f);
        LeanTween.rotateZ(botonCreditos, 5, 1f).setEaseOutCubic().setDelay(1.5f);

        //audioSource.PlayOneShot(cartaAudio);

        LeanTween.moveLocalY(botonGuia, -320, 1.5f).setEaseOutCubic().setDelay(2f);
        LeanTween.rotateZ(botonGuia, 1, 1f).setEaseOutCubic().setDelay(2f);
    }
}
