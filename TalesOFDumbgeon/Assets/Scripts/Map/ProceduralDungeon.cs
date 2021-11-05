using System;
using System.Collections;
using System.Collections.Generic;
using Map;
using UnityEngine;
using Random = UnityEngine.Random;


public class ProceduralDungeon : MonoBehaviour
{
    //Max Room sizes
    public const int MaxSizeX = 10;
    public const int MaxSizeY = 10;
    public int MaxMaps;
    public int MaxBigRooms;
    private int actualBigRooms;
    private bool endRoom = false;
    [SerializeField] private List<MapInstance> posibleMaps;
    private RoomNode[,] _rooms;
    [NonSerialized] public Vector2 ActualPos;
    void Start()
    {
        _rooms = new RoomNode[MaxSizeX,MaxSizeY];
        for (int i = 0; i < MaxSizeX; i++)
        {
            for (int j = 0; j < MaxSizeY; j++)
            {
                _rooms[i, j] = new RoomNode();
            }
        }
        int posX = Random.Range(0, MaxSizeX);;
        int posY = 0;
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
        UpdateMap(newMap, posX, posY);
        int maxIterations = 1;
        int numSalas;
        do
        {
            actualBigRooms = 0;
            endRoom = false;
            numSalas = MapIteration(posX, posY+1);
            maxIterations--;
        } while (((numSalas < MaxMaps) || !endRoom));
    }

    private int MapIteration(int posX, int posY)
    {
        bool validMap = false;
        MapInstance newMap;
        do
        {
            validMap = true;
            int nextMap = Random.Range(0, posibleMaps.Count);
            
            newMap = posibleMaps[nextMap];
            if (newMap.roomType == MapInstance.RoomType.Start)
                validMap = false;
            else  if (newMap.roomType == MapInstance.RoomType.Big && actualBigRooms>=MaxBigRooms)
                validMap = false;
            else if (newMap.roomType == MapInstance.RoomType.End && (posY < (MaxSizeY - 1) || endRoom))
                validMap = false;
            else if (!AreDoorsValid(_rooms[posX, posY].Directions, newMap.doorsOrientations, posX, posY))
                validMap = false;
        } while (!validMap);

        _rooms[posX, posY].Map = Instantiate(newMap);
        _rooms[posX, posY].RoomState = RoomNode.State.Complete;

        if (newMap.roomType == MapInstance.RoomType.End)
        {
            endRoom = true;
            return 1;
        }

        if (newMap.roomType == MapInstance.RoomType.Big)
            actualBigRooms++;
        
        
        
            
        
        int numHijos = 1;
        if (newMap.doorsOrientations.North)
        {
            if (_rooms[posX, posY + 1].RoomState != RoomNode.State.Null)
            {
                _rooms[posX, posY + 1].Directions[(int) RoomNode.Cardinal.South] = RoomNode.State.Complete;
            }
            else
            {
                numHijos += MapIteration(posX, posY + 1);
            }
        }
        if (newMap.doorsOrientations.South)
        {
            if (_rooms[posX, posY - 1].RoomState != RoomNode.State.Null)
            {
                _rooms[posX, posY - 1].Directions[(int) RoomNode.Cardinal.South] = RoomNode.State.Complete;
            }
            else
            {
                numHijos += MapIteration(posX, posY - 1);
            }
        }
        if (newMap.doorsOrientations.East)
        {
            if (_rooms[posX + 1 , posY].RoomState != RoomNode.State.Null)
            {
                _rooms[posX + 1, posY].Directions[(int) RoomNode.Cardinal.South] = RoomNode.State.Complete;
            }
            else
            {
                numHijos += MapIteration(posX  + 1, posY);
            }
        }
        if (newMap.doorsOrientations.South)
        {
            if (_rooms[posX-1, posY].RoomState != RoomNode.State.Null)
            {
                _rooms[posX-1, posY].Directions[(int) RoomNode.Cardinal.South] = RoomNode.State.Complete;
            }
            else
            {
                numHijos += MapIteration(posX-1, posY );
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
        
        //Check there arent existing rooms
        /*
        if (orientations.North && _rooms[posX, posY+1].RoomState == RoomNode.State.Complete)
            return false;
        if (orientations.South && _rooms[posX, posY-1].RoomState == RoomNode.State.Complete)
            return false;
        if (orientations.East && _rooms[posX+1, posY].RoomState == RoomNode.State.Complete)
            return false;
        if (orientations.West && _rooms[posX-1, posY].RoomState == RoomNode.State.Complete)
            return false;
        */
        return true;

    }
    private void UpdateMap(MapInstance map, int posX, int posY)
    {
        _rooms[posX, posY].Map = map;
        _rooms[posX, posY].RoomState = RoomNode.State.Complete;
        MapInstance.Orientations orientations = map.doorsOrientations;
        if (orientations.North)
        {
            _rooms[posX, posY + 1].RoomState = RoomNode.State.Empty;
            _rooms[posX, posY+ 1].Directions[(int) RoomNode.Cardinal.South] = RoomNode.State.Complete;
        }
        if (orientations.South)
        {
            _rooms[posX, posY - 1].RoomState = RoomNode.State.Empty;
            _rooms[posX, posY - 1].Directions[(int) RoomNode.Cardinal.North] = RoomNode.State.Complete;
        }
        if (orientations.East)
        {
            _rooms[posX+1, posY].RoomState = RoomNode.State.Empty;
            _rooms[posX+1, posY].Directions[(int) RoomNode.Cardinal.West] = RoomNode.State.Complete;
        }
        if (orientations.West)
        {
            _rooms[posX-1, posY].RoomState = RoomNode.State.Empty;
            _rooms[posX-1, posY].Directions[(int) RoomNode.Cardinal.East] = RoomNode.State.Complete;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
