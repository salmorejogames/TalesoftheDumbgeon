using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip FlipCard, GolpeBaston, GolpeEspada, GolpeLanza, HechizoAire, HechizoCaos, HechizoFuego, HechizoHielo, HechizoRoca, MonsterHurt, PasosMazmorra, SonidoBendicion, SonidoMaldicion, Stadtnarr_hurt;
    [NonSerialized] public AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayPasos()
    {
        audioSrc.clip = PasosMazmorra;
        audioSrc.Play();
    }
                

    public void PlaySound (string clip)
    {
        switch (clip)
        {
            case "flipcard":
                audioSrc.PlayOneShot(FlipCard);
                break;
            case "golpebaston":
                audioSrc.PlayOneShot(GolpeBaston);
                break;
            case "golpeespada":
                audioSrc.PlayOneShot(GolpeEspada);
                break;
            case "golpelanza":
                audioSrc.PlayOneShot(GolpeLanza);
                break;
            case "hechizoaire":
                audioSrc.PlayOneShot(HechizoAire);
                break;
            case "hechizocaos":
                audioSrc.PlayOneShot(HechizoCaos);
                break;
            case "hechizofuego":
                audioSrc.PlayOneShot(HechizoFuego);
                break;
            case "hechizoroca":
                audioSrc.PlayOneShot(HechizoRoca);
                break;
            case "hechizohielo":
                audioSrc.PlayOneShot(HechizoHielo);
                break;
            case "monsterhurt":
                audioSrc.PlayOneShot(MonsterHurt);
                break;
            case "sonidobendicion":
                audioSrc.PlayOneShot(SonidoBendicion);
                break;
            case "sonidomaldicion":
                audioSrc.PlayOneShot(SonidoMaldicion);
                break;
            case "stadtnarrhurt":
                audioSrc.PlayOneShot(Stadtnarr_hurt);
                break;

        }
    }

}
