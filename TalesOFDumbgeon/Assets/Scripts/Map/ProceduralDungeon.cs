using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ProceduralDungeon : MonoBehaviour
{
    //Max Room sizes
    public const int MaxSizeX = 10;
    public const int MaxSizeY = 10;
    [SerializeField] private int minRooms;
    [SerializeField] private int maxRooms;
    public int MaxBigRooms;
    private int actualBigRooms;
    private bool endRoom = false;
    [SerializeField] private List<MapInstance> posibleMaps;
    private RoomNode[,] _rooms;
    [NonSerialized] public Vector2Int InitialPos;
    private MapInstance endMap;
    void Awake()
    {
        endMap = posibleMaps.Find((map) => map.roomType == MapInstance.RoomType.End);
        _rooms = new RoomNode[MaxSizeX,MaxSizeY];
        int posX = Random.Range(1, MaxSizeX-1);;
        int posY = 0;
        InitialPos = new Vector2Int(posX, posY);
        MapInstance newMap = null;
        foreach (var map in posibleMaps)
        {
            if (map.roomType == MapInstance.RoomType.Start)
            {
                newMap = map;
                break;
            }
        }

        if (newMap == null)
        {
            newMap = posibleMaps[0];
        }

        newMap.gameObject.transform.position = Vector3.zero;
        Debug.Log("Initial map in " + posX + "," + posY);
       
        int maxIterations = 1;
        int numSalas;
        do
        {
            ResetRooms();
            UpdateMap(newMap, posX, posY);
            actualBigRooms = 0;
            endRoom = false;
            numSalas = MapIteration(posX, posY+1, newMap);
            maxIterations--;
            Debug.Log(numSalas);
        } while (((numSalas < minRooms) || numSalas>maxRooms) || !AddBossRoom());
        InstantiateMaps();
    }

    public bool AddBossRoom()
    {
        if (endRoom)
            return true;

        for (int i = MaxSizeX - 1; i >= 0; i--)
        {
            for (int j = MaxSizeY - 1; j >= 0; j--)
            {
                if (_rooms[i, j].RoomState != RoomNode.State.Null &&
                    _rooms[i, j].Map.roomType == MapInstance.RoomType.Close && _rooms[i, j].Map.doorsOrientations.South)
                {
                    Debug.Log("Boss Room Created");
                    _rooms[i, j].Map = endMap;
                    endRoom = true;
                    return true;
                }
            }
        }
        Debug.Log("Couldnt generate Boos Room");
        return false;
    }
    
    public MapInstance GetRoom(int x, int y)
    {
        return _rooms[x, y].Map;
    }

    private void InstantiateMaps()
    {
        for (int i = 0; i < MaxSizeX; i++)
        {
            for (int j = 0; j < MaxSizeY; j++)
            {
                if (_rooms[i, j].RoomState != RoomNode.State.Null)
                {
                    _rooms[i, j].Map = Instantiate(_rooms[i, j].Map);
                    _rooms[i, j].Map.gameObject.SetActive(false); 
                }
            }
        }
        
    }
    private int MapIteration(int posX, int posY, MapInstance previous)
    {
        bool validMap = false;
        MapInstance newMap;
        List<MapInstance> posibles;
        switch (previous.roomType)
        {
            case MapInstance.RoomType.Big:
                posibles = posibleMaps.FindAll((map) => (map.roomType != MapInstance.RoomType.Start && map.roomType != MapInstance.RoomType.Big));
                break;
            case MapInstance.RoomType.Small:
                posibles = posibleMaps.FindAll((map) => (map.roomType != MapInstance.RoomType.Start));
                break;
            case MapInstance.RoomType.Corridor:
                posibles = posibleMaps.FindAll((map) => (map.roomType != MapInstance.RoomType.Start && map.roomType != MapInstance.RoomType.Corridor));
                break;
            case MapInstance.RoomType.Start:
                posibles = posibleMaps.FindAll((map) => (map.roomType == MapInstance.RoomType.Big));
                break;
            default:
                posibles = posibleMaps.FindAll((map) => (map.roomType != MapInstance.RoomType.Start));
                Debug.LogError("Generando una sala despues de una sala cerrada");
                break;
        }
        
        do
        {
            validMap = true;
            int nextMap = Random.Range(0, posibles.Count);
            
            newMap = posibles[nextMap];
            if (newMap.roomType == MapInstance.RoomType.Start)
                validMap = false;
            else  if (newMap.roomType == MapInstance.RoomType.Big && actualBigRooms>=MaxBigRooms)
                validMap = false;
            else if (newMap.roomType == MapInstance.RoomType.End && (posY < (MaxSizeY - 1) || endRoom))
                validMap = false;
            else if (!AreDoorsValid(_rooms[posX, posY].Directions, newMap.doorsOrientations, posX, posY))
                validMap = false;
        } while (!validMap);

        //Debug.Log("Map generated in " + posX + "," + posY + " map: " + newMap.name + " rooms: N:" + newMap.doorsOrientations.North + " S: " + newMap.doorsOrientations.South + " E: " + newMap.doorsOrientations.East + " W: " + newMap.doorsOrientations.West);
       
        UpdateMap(newMap, posX, posY);

        if (newMap.roomType == MapInstance.RoomType.End)
        {
            endRoom = true;
            return 1;
        }

        if (newMap.roomType == MapInstance.RoomType.Big)
            actualBigRooms++;
        
        
        
            
        
        int numHijos = 1;
        
       
        if (newMap.doorsOrientations.South)
        {
            if (_rooms[posX, posY - 1].RoomState == RoomNode.State.Complete)
            {
                _rooms[posX, posY - 1].Directions[(int) RoomNode.Cardinal.North] = RoomNode.State.Complete;
            }
            else
            {
                numHijos += MapIteration(posX, posY - 1, newMap);
            }
        }
        if (newMap.doorsOrientations.East)
        {
            if (_rooms[posX + 1 , posY].RoomState == RoomNode.State.Complete)
            {
                _rooms[posX + 1, posY].Directions[(int) RoomNode.Cardinal.West] = RoomNode.State.Complete;
            }
            else
            {
                numHijos += MapIteration(posX  + 1, posY, newMap);
            }
        }
        if (newMap.doorsOrientations.West)
        {
            if (_rooms[posX-1, posY].RoomState == RoomNode.State.Complete)
            {
                _rooms[posX-1, posY].Directions[(int) RoomNode.Cardinal.East] = RoomNode.State.Complete;
            }
            else
            {
                numHijos += MapIteration(posX-1, posY, newMap );
            }
        }
        if (newMap.doorsOrientations.North)
        {
            if (_rooms[posX, posY + 1].RoomState == RoomNode.State.Complete)
            {
                _rooms[posX, posY + 1].Directions[(int) RoomNode.Cardinal.South] = RoomNode.State.Complete;
            }
            else
            {
                numHijos += MapIteration(posX, posY + 1, newMap);
            }
        }
        return numHijos;
    }

    private bool AreDoorsValid(RoomNode.State[] directions, MapInstance.Orientations orientations, int posX, int posY)
    {
        //Si hay una sala en esa direccion (direccion distinto de null) y la sala no tiene puerta en esa direccion, se devuelve false
        if (directions[0] != RoomNode.State.Null && !orientations.North)
            return false;
        if (directions[1] != RoomNode.State.Null && !orientations.South)
            return false;
        if (directions[2] != RoomNode.State.Null && !orientations.East)
            return false;
        if (directions[3] != RoomNode.State.Null && !orientations.West)
            return false;
        //Check map bounds
        if (orientations.North && posY >= MaxSizeY - 1)
            return false;
        if (orientations.South && posY <= 0)
            return false;
        if (orientations.East && posX>= MaxSizeX - 1)
            return false;
        if (orientations.West && posX <= 0)
            return false;
        
        //Check there arent existing rooms without doors towards our new room
        
        if (orientations.North && _rooms[posX, posY+1].RoomState == RoomNode.State.Complete && !_rooms[posX, posY+1].Map.doorsOrientations.South)
            return false;
        if (orientations.South && _rooms[posX, posY-1].RoomState == RoomNode.State.Complete && !_rooms[posX, posY-1].Map.doorsOrientations.North)
            return false;
        if (orientations.East && _rooms[posX+1, posY].RoomState == RoomNode.State.Complete && !_rooms[posX+1, posY].Map.doorsOrientations.West)
            return false;
        if (orientations.West && _rooms[posX-1, posY].RoomState == RoomNode.State.Complete && !_rooms[posX-1, posY].Map.doorsOrientations.East)
            return false;
        
        return true;

    }

    private void ResetRooms()
    {
        for (int i = 0; i < MaxSizeX; i++)
        {
            for (int j = 0; j < MaxSizeY; j++)
            {
                _rooms[i, j] = new RoomNode();
            }
        }
    }
    private void UpdateMap(MapInstance map, int posX, int posY)
    {
        _rooms[posX, posY].Map = map;
        _rooms[posX, posY].RoomState = RoomNode.State.Complete;
        
        MapInstance.Orientations orientations = map.doorsOrientations;
        if (orientations.North)
        {
            //_rooms[posX, posY + 1].RoomState = RoomNode.State.Empty;
            _rooms[posX, posY+ 1].Directions[(int) RoomNode.Cardinal.South] = RoomNode.State.Complete;
        }
        if (orientations.South)
        {
            //_rooms[posX, posY - 1].RoomState = RoomNode.State.Empty;
            _rooms[posX, posY - 1].Directions[(int) RoomNode.Cardinal.North] = RoomNode.State.Complete;
        }
        if (orientations.East)
        {
            //rooms[posX+1, posY].RoomState = RoomNode.State.Empty;
            _rooms[posX+1, posY].Directions[(int) RoomNode.Cardinal.West] = RoomNode.State.Complete;
        }
        if (orientations.West)
        {
            //_rooms[posX-1, posY].RoomState = RoomNode.State.Empty;
            _rooms[posX-1, posY].Directions[(int) RoomNode.Cardinal.East] = RoomNode.State.Complete;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
