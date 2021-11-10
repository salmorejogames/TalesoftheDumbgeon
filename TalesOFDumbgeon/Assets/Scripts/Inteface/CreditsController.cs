﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TerminarCreditos", 41.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TerminarCreditos()
    {
        SceneManager.LoadScene("ClickParaEmpezar");
    }

    public void SaltarCreditos()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
