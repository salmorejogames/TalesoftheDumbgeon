using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float tiempoSala;
    public int dificultadActual;
    public int dificultadAnterior;
    public enum Modo { Facil, Medio, Dificil};
    public Modo modoActual;
    private float tiempoAnterior;
    private float limiteFacilT1 = 60f;
    private float limiteFacilT2 = 90f;
    private float limiteFacilT3 = 120f;
    private float limiteMedioT1 = 35f;
    private float limiteMedioT2 = 60f;
    private float limiteMedioT3 = 120f;
    private float limiteMedioT4 = 35f;
    private float limiteMedioT5 = 60f;
    private float limiteMedioT6 = 120f;
    private float limiteDificilT1 = 35f;
    private float limiteDificilT2 = 60f;
    private float limiteDificilT3 = 120f;
    private int limiteDificultad1 = 4;
    private int limiteDificultad2 = 7;
    public bool Stop = false;
     

    // Start is called before the first frame update
    void Start()
    {
        modoActual = Modo.Medio;
        dificultadActual = 0;
        tiempoSala = 0;
    }

    public int Facilitar()
    {
        dificultadActual -= 1;
        Debug.Log("Facilito " + dificultadActual);
        return -1;
    }

    public int Dificultar()
    {
        dificultadActual += 1;
        Debug.Log("Dificilito " + dificultadActual);
        return 1;
    }

    public void StartCount()
    {
        tiempoSala = 0;
    }

    public void StopCount()
    {
        Stop = true;
        dificultadAnterior = dificultadActual;
        tiempoAnterior = tiempoSala;
        Debug.Log("tiempo tardado: " + tiempoSala);
    } 

    public int CalcularModo()
    {
        if ((tiempoAnterior > limiteFacilT1 && dificultadAnterior <= limiteDificultad1) ||
            (tiempoAnterior >= limiteFacilT2  && dificultadAnterior < limiteDificultad2) 
            || (tiempoAnterior > limiteFacilT3 && dificultadAnterior >= limiteDificultad2))
        {
            return Facilitar();
        }
        /*
        if ((tiempoSala >= limiteMedioT1 && tiempoSala <= limiteMedioT2 && dificultadSala < limiteDificultad1 ) 
            || (tiempoSala >= limiteMedioT3 && tiempoSala <= limiteMedioT4 && dificultadSala >= limiteDificultad1 && dificultadSala < limiteDificultad2)
            || (tiempoSala >=limiteMedioT5 && tiempoSala <= limiteMedioT6 && dificultadSala > limiteDificultad2))
        {
            modoActual = Modo.Medio;
        }*/

        if ((tiempoAnterior < limiteDificilT1 && dificultadAnterior < limiteDificultad1) 
            || (tiempoAnterior < limiteDificilT2 && dificultadAnterior < limiteDificultad2 && dificultadAnterior >= limiteDificultad1)
            || (tiempoAnterior < limiteDificilT3  && dificultadAnterior >= limiteDificultad2))
        {
            return Dificultar();
        }
        return 0;
    }
}