using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAnatomy : MonoBehaviour
{
    public int direction;

    public bool sex = true; //True hombre /False Mujer

    public enum EquipmentClasss
    {
        Normal,
        Rogue,
        Wizard,
        Warrior
    }

    public GameObject head;

    public GameObject body;

    public GameObject patas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
