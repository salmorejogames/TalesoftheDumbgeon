using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayInterfaceController : MonoBehaviour
{
    private bool botonArmaPulsado;
    private bool botonArmaduraPulsado;
    private bool botonHechizoPulsado;
    private bool botonMaldicionPulsado;

    [SerializeField] private GameObject contArma;

    // Start is called before the first frame update
    void Start()
    {
        botonArmaPulsado = false;
        botonArmaduraPulsado = false;
        botonHechizoPulsado = false;
        botonMaldicionPulsado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HabilidadArma()
    {
        if (!botonArmaPulsado)
        {
            contArma.SetActive(true);
            botonArmaPulsado = true;
        }
        else
        {
            contArma.SetActive(false);
            botonArmaPulsado = false;
        }
    }
}
