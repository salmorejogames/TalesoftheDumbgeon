using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugText : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI text;

    private void Update()
    {
        text.text = "";
    }

    public void SetText(string newText)
    {
        text.text = newText;
    }

    public void AddText(string textAded)
    {
        text.text += textAded;
    }
}
