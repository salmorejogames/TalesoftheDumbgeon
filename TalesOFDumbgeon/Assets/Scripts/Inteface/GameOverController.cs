using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject blackPanel;
    [SerializeField] private Animator blackPanelAnimator;

    [SerializeField] private AudioSource gameOverAS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reintentar()
    {
        blackPanel.SetActive(true);
        blackPanelAnimator.Play("FadeOut", 0, 0);

        StartCoroutine(EsperarReintentar());
        //SceneManager.LoadScene("IsometricScene");
    }

    public void Salir()
    {
        SceneManager.LoadScene("ClickParaEmpezar");
    }

    IEnumerator EsperarReintentar()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("IsometricScene");
    }
}
