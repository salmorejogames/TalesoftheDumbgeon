using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : ScriptableObject
{
    public string[] parameters;
    
    public abstract string Start();
}
