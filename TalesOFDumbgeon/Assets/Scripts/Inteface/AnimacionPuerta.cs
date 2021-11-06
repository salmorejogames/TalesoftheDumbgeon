using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class AnimacionPuerta : MonoBehaviour
{
    [SerializeField] private InterfaceControls iuInput;
    [SerializeField] private GameObject fondo;
    [SerializeField] private GameObject puerta;
    [SerializeField] private GameObject barba;
    [SerializeField] private GameObject boca;
    [SerializeField] private GameObject cejaIzda;
    [SerializeField] private GameObject cejaDcha;
    [SerializeField] private GameObject cesped;
    [SerializeField] private GameObject columnas;
    [SerializeField] private GameObject ojos;
    [SerializeField] private GameObject clickEmpezar;

    private void Awake()
    {
        iuInput = new InterfaceControls();
        iuInput.Menuprincipal.Animacionpuerta.performed += ctx => HacerClick();
    }

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.init(1600);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        iuInput.Menuprincipal.Enable();
    }

    private void OnDisable()
    {
        iuInput.Menuprincipal.Disable();
    }
    /*
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickEmpezar.SetActive(false);
            LeanTween.moveLocalX(cejaIzda, -42, .25f);
            LeanTween.moveLocalX(cejaDcha, 34, .25f);
            LeanTween.rotateZ(cejaIzda, -20, .25f);
            LeanTween.rotateZ(cejaDcha, 20, .25f);

            StartCoroutine(AbrirDumbgeon());
        }
    }
    */

    void HacerClick()
    {
        clickEmpezar.SetActive(false);
        LeanTween.moveLocalX(cejaIzda, -58, .25f);
        LeanTween.moveLocalX(cejaDcha, 58, .25f);
        LeanTween.rotateZ(cejaIzda, -20, .25f);
        LeanTween.rotateZ(cejaDcha, 20, .25f);

        StartCoroutine(AbrirDumbgeon());
    }

    IEnumerator AbrirDumbgeon()
    {
        yield return new WaitForSeconds(1);
        //LeanTween.moveLocalY(barba, -90, 2f);
        //LeanTween.moveLocalY(columnas, 70, 2f);
        LeanTween.moveLocalY(barba, -250, 1f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.moveLocalY(columnas, 250, 1f).setEase(LeanTweenType.easeOutBounce);

        StartCoroutine(EntrarDumbgeon());
    }

    IEnumerator EntrarDumbgeon()
    {
        yield return new WaitForSeconds(2);
        LeanTween.moveY(cesped, -100, .5f);
        LeanTween.moveLocalX(puerta, 0, .5f);
        LeanTween.moveLocalY(puerta, 1600, .5f);
        LeanTween.scale(puerta, new Vector2(15f, 15f), .5f);
        LeanTween.scale(fondo, new Vector2(15f, 15f), .5f);

        StartCoroutine(MenuPrincipal());
    }

    IEnumerator MenuPrincipal()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
