using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenuController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static SettingsMenuController instance;
    public float volumen;

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("Volumen", volume);
        volumen = volume;
        Debug.Log(volumen);
    }
}
