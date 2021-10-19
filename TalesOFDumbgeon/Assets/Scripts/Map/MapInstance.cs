using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInstance : MonoBehaviour
{
    public Vector2 dimensions;
    [SerializeField] private Collider2D mapTrigger;
    
    public void SetTrigger(bool active)
    {
        mapTrigger.enabled = active;
    }
    
}
