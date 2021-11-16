using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDmg : MonoBehaviour
{
    public float Amount;
    public Elements.Element Element;
    public Vector3 Origen;
    public string OwnerTag;

    public void SetSpellDmgStats(float amount, Elements.Element element, Vector3 origen, string ownerTag)
    {
        Amount = amount;
        Element = element;
        Origen = origen;
        OwnerTag = ownerTag;
    }


}
