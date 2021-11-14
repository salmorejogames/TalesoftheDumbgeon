using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    private InterfaceControls iuInput;
    [SerializeField] private GameObject menuPausa;

    private void Awake()
    {
        iuInput = new InterfaceControls();
        iuInput.Menupausa.Pausa.performed += ctx => ActivarMenuPausa();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        iuInput.Menupausa.Enable();
    }

    private void OnDisable()
    {
        iuInput.Menupausa.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarMenuPausa()
    {
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }

    public void Volver()
    {
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }

    public void Ajustes()
    {

    }

    public void Salir()
    {
        SceneManager.LoadScene("ClickParaEmpezar");
    }
}
