using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class AnimacionPuerta : MonoBehaviour
{

    private InterfaceControls iuInput;

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

    [SerializeField] private AudioClip abrirDumbbgeonAudio;
    [SerializeField] private AudioClip entrarDumbgeonAudio;
    [SerializeField] private AudioSource audioSource;
    //[SerializeField] private AudioSource audioSourceFondo;

    private bool click;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSourceFondo = GetComponent<AudioSource>();

        iuInput = new InterfaceControls();
        iuInput.Menuprincipal.Animacionpuerta.performed += ctx => HacerClick();
    }

    // Start is called before the first frame update
    void Start()
    {
        //audioSourceFondo.Play();
        click = false;
        LeanTween.init(3200);
    }

    private void OnEnable()
    {
        iuInput.Menuprincipal.Enable();
    }

    private void OnDisable()
    {
        iuInput.Menuprincipal.Disable();
    }

    void HacerClick()
    {
        if (!click)
        {
            clickEmpezar.SetActive(false);
            LeanTween.moveLocalX(cejaIzda, -58, .25f);
            LeanTween.moveLocalX(cejaDcha, 58, .25f);
            LeanTween.rotateZ(cejaIzda, -20, .25f);
            LeanTween.rotateZ(cejaDcha, 20, .25f);
            click = true;

            StartCoroutine(AbrirDumbgeon());
        }
    }

    IEnumerator AbrirDumbgeon()
    {
        yield return new WaitForSeconds(1);

        audioSource.clip = abrirDumbbgeonAudio;
        audioSource.PlayOneShot(abrirDumbbgeonAudio);

        LeanTween.moveLocalY(barba, -250, 1f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.moveLocalY(columnas, 250, 1f).setEase(LeanTweenType.easeOutBounce);

        StartCoroutine(EntrarDumbgeon());
    }

    IEnumerator EntrarDumbgeon()
    {
        yield return new WaitForSeconds(2);

        audioSource.clip = entrarDumbgeonAudio;
        audioSource.volume = .7f;
        audioSource.pitch = 1;
        audioSource.PlayOneShot(entrarDumbgeonAudio);

        LeanTween.moveY(cesped, -100, .5f);
        LeanTween.moveLocalX(puerta, 0, .5f);
        LeanTween.moveLocalY(puerta, 1600, .5f);
        LeanTween.scale(puerta, new Vector2(15f, 15f), .5f);
        LeanTween.scale(fondo, new Vector2(15f, 15f), .5f);

        //audioSourceFondo.Stop();

        StartCoroutine(MenuPrincipal());
    }

    IEnumerator MenuPrincipal()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
