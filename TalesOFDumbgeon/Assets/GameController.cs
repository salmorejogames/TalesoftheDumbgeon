using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float tiempoSala;
    public int dificultadSala;
    public int dificultadInicial;
    public enum Modo { Facil, Medio, Dificil};
    public Modo modoActual;
    private float tiempoInicio;
    private float tiempoFinal;
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
    private bool Stop = false;
     

    // Start is called before the first frame update
    void Start()
    {
        modoActual = Modo.Medio;
        dificultadSala = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Facilitar()
    {
        dificultadSala -= 1;
        Debug.Log("Facilito " + dificultadSala);
        return -1;
    }

    public int Dificultar()
    {
        dificultadSala += 1;
        Debug.Log("Dificilito " + dificultadSala);
        return 1;
    }

    public void StartCount()
    {
        tiempoSala = 0;
    }

    public void StopCount()
    {
        Stop = true;
    }
    public void TimeCount()
    {
        if (!Stop) 
        {
            tiempoSala += Time.deltaTime;
        }
    }

    public int CalcularModo()
    {
        if ((tiempoSala > limiteFacilT1 && dificultadInicial <= limiteDificultad1) ||
            (tiempoSala >= limiteFacilT2  && dificultadInicial < limiteDificultad2) 
            || (tiempoSala  > limiteFacilT3 && dificultadInicial >= limiteDificultad2))
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

        if ((tiempoSala < limiteDificilT1 && dificultadInicial < limiteDificultad1) 
            || (tiempoSala < limiteDificilT2 && dificultadInicial < limiteDificultad2 && dificultadInicial >= limiteDificultad1)
            || (tiempoSala <limiteDificilT3  && dificultadInicial >= limiteDificultad2))
        {
            return Dificultar();
        }
        return 0;
    }
}
