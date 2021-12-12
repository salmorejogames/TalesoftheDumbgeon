using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JojoSounds : MonoBehaviour
{
    [SerializeField] private AudioClip jojoDmg;
    [SerializeField] private AudioClip jojoDisparo;
    [SerializeField] private AudioClip jojoEscopetazo;
    [SerializeField] private AudioClip jojoArea;
    [SerializeField] private AudioClip jojoEspecial;

    public enum JojoSoundList
    {
        Dmg,
        Disparo,
        Area,
        Escopetazo,
        
    }
    
}
