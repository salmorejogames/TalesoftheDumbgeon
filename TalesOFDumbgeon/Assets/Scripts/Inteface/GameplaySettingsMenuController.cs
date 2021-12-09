using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameplaySettingsMenuController : MonoBehaviour
{
    public AudioMixer audioMixerMusica;
    public AudioMixer audioMixerEfectos;

    public float volumen;

    public Slider sliderMusica;
    public Slider sliderEfectos;

    public void Awake()
    {
        audioMixerMusica.GetFloat("VolumenMusica", out volumen);
        audioMixerEfectos.GetFloat("VolumenEfectos", out volumen);

        sliderMusica.value = volumen;
    }

    public void SetVolumenMusica(float volume)
    {
        audioMixerMusica.SetFloat("VolumenMusica", volume);
        volumen = volume;
    }

    public void SetVolumenEfectos(float volume)
    {
        audioMixerEfectos.SetFloat("VolumenEfectos", volume);
        volumen = volume;
    }
}
