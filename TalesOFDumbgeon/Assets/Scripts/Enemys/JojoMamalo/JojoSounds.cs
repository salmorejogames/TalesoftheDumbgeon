using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JojoSounds : MonoBehaviour
{
    [SerializeField] private AudioClip jojoDmg;
    [SerializeField] private AudioClip jojoDisparo;
    [SerializeField] private AudioClip jojoArea;
    [SerializeField] private AudioClip jojoTp;

    [SerializeField] private AudioSource source;
    public enum JojoSoundList
    {
        Dmg,
        Disparo,
        Area,
        Tp
    }

    public void LaunchSound(JojoSoundList sound)
    {
        switch (sound)
        {
            case JojoSoundList.Dmg:
                source.PlayOneShot(jojoDmg);
                break;
            case JojoSoundList.Disparo:
                source.PlayOneShot(jojoDisparo);
                break;
            case JojoSoundList.Area:
                source.PlayOneShot(jojoArea);
                break;
            case JojoSoundList.Tp:
                source.PlayOneShot(jojoTp);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sound), sound, null);
        }
    }
    
}
