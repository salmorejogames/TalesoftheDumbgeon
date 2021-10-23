using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapInstance : MonoBehaviour
{
    [NonSerialized] public Vector2Int Dimensions;
    [SerializeField] private Tilemap ground;
    [SerializeField] private Collider2D mapTrigger;

    private void Awake()
    {
        ground.CompressBounds();
        Dimensions = (Vector2Int) ground.size;
    }

    public void SetTrigger(bool active)
    {
        mapTrigger.enabled = active;
    }
    
}
