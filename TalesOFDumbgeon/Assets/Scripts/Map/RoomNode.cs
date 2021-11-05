using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNode
{
    public const int NUM_DIRECTIONS = 4;

    public enum State
    {
        Null = -1,
        Empty = 0,
        Complete = 1
    }
    public enum Cardinal
    {
        North = 0,
        South = 1,
        East = 2,
        West = 3
    }
    
    private MapInstance _map;
    public State RoomState;
    private State[] _directions;

    public RoomNode()
    {
        _directions = new State[NUM_DIRECTIONS];
        for (int i = 0; i < NUM_DIRECTIONS; i++)
        {
            _directions[i] = State.Null;
        }

        _map = null;
        RoomState = State.Null;
    }

    public RoomNode(MapInstance map)
    {
        _directions = new State[NUM_DIRECTIONS];
        for (int i = 0; i < NUM_DIRECTIONS; i++)
        {
            _directions[i] = State.Null;
        }

        _map = map;
        RoomState = State.Empty;
    }
    
    public RoomNode(State state)
    {
        _directions = new State[NUM_DIRECTIONS];
        for (int i = 0; i < NUM_DIRECTIONS; i++)
        {
            _directions[i] = State.Null;
        }

        _map = null;
        RoomState = state;
    }

    public MapInstance Map
    {
        get => _map;
        set => _map = value;
    }

    public State[] Directions
    {
        get => _directions;
        set => _directions = value;
    }
}
