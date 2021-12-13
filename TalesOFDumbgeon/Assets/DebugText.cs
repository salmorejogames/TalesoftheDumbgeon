using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugText : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI text;

    public void SetText(string newText)
    {
        text.text = newText;
    }
}
