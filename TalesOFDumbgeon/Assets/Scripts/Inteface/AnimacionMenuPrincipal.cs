using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionMenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject titulo;
    [SerializeField] private GameObject botonJugar;
    [SerializeField] private GameObject botonAjustes;
    [SerializeField] private GameObject botonCreditos;

    private bool terminado;

    // Start is called before the first frame update
    void Start()
    {
        terminado = false;
        //LeanTween.init(3200);
        LeanTween.moveLocalY(titulo, 190, 1.5f).setEaseOutCubic();
        LeanTween.rotateZ(titulo, -85, 1f).setEaseOutCubic();

        LeanTween.moveLocalX(botonJugar, -13, 1.5f).setEaseOutCubic().setDelay(1.5f);
        LeanTween.moveLocalY(botonJugar, -190, 1.5f).setEaseOutCubic().setDelay(1.5f);
        LeanTween.rotateZ(botonJugar, -5, 1f).setEaseOutCubic().setDelay(1.5f);

        LeanTween.moveLocalX(botonAjustes, -420, 1.5f).setEaseOutCubic().setDelay(1.5f);
        LeanTween.moveLocalY(botonAjustes, -180, 1.5f).setEaseOutCubic().setDelay(1.5f);
        LeanTween.rotateZ(botonAjustes, 15, 1f).setEaseOutCubic().setDelay(1.5f);

        LeanTween.moveLocalX(botonCreditos, 385, 1.5f).setEaseOutCubic().setDelay(1.5f);
        LeanTween.moveLocalY(botonCreditos, -160, 1.5f).setEaseOutCubic().setDelay(1.5f);
        LeanTween.rotateZ(botonCreditos, 5, 1f).setEaseOutCubic().setDelay(1.5f);
    }
}
