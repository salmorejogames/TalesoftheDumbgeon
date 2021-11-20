using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameplaySettingsMenuController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float volumen;
    public Slider slider;

    public void Awake()
    {
        audioMixer.GetFloat("Volumen", out volumen);
        slider.value = volumen;
        Debug.Log("VOLUMEN MUSICA DEL JUEGO" + volumen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volumen", volume);
        volumen = volume;
        Debug.Log(volumen);
    }
}
