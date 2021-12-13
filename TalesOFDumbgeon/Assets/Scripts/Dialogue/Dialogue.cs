using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    //public string name;
    public List<string> name = new List<string>();

    [TextArea(3, 50)]
    //public string[] sentences;
    public List<string> sentences = new List<string>();

    public List<string> face = new List<string>();
}
