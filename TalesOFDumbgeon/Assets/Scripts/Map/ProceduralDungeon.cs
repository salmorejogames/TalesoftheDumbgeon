using System;
using System.Collections;
using System.Collections.Generic;
using Map;
using UnityEngine;
using Random = UnityEngine.Random;


public class ProceduralDungeon : MonoBehaviour
{
    // Start is called before the first frame update
    public const int MaxSizeX = 5;
    public const int MaxSizeY = 5;
    
    [SerializeField] private List<MapInstance> posibleMaps;
    private RoomState[,] _mapInstances;
    [NonSerialized] public Vector2 ActualPos;
    void Start()
    {
        _mapInstances = new RoomState[MaxSizeX,MaxSizeY];
        int posX = 0;
        int posY = Random.Range(0, MaxSizeY);
        ActualPos = new Vector2(posX, posY);
        MapInstance newMap = null;
        foreach (var map in posibleMaps)
        {
            if (map.roomType == MapInstance.RoomType.Start)
            {
                newMap = Instantiate(map);
                break;
            }
        }
        if(newMap ==null)
            newMap = Instantiate(posibleMaps[0]);
        newMap.gameObject.transform.position = Vector3.zero;
        _mapInstances[posX, posY] = new RoomState(newMap);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
