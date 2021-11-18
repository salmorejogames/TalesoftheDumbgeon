using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShader : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Material> materialList;

    private void Start()
    {
        
        for (int i = 0; i < materialList.Count; i++)
        {
            Debug.Log(i);
            Color color = SingletoneGameController.InfoHolder.LoadColor((Elements.Element) i-1);
            materialList[i].SetColor("_color", color);
        }
    }

    public Material GetMaterial(Elements.Element element)
    {
        return materialList[((int) element) + 1];
    }
}
