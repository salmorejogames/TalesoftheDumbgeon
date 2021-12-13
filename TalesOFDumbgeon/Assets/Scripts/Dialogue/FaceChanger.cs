using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceChanger : MonoBehaviour
{
    public Sprite[] faceSprite = new Sprite[4];

    public void UpdateFace(int newFace)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = faceSprite[newFace];
    }
}
