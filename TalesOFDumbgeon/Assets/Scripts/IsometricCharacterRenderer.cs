﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCharacterRenderer : MonoBehaviour
{
    public static readonly string[] staticDirections = {"Static NW", "Static NW",  "Static SW", "Static SW", "Static SE", "Static SE", "Static NE", "Static NE"};
    public static readonly string[] runDirections = {"Run NW", "Run NE", "Run SW", "Run SE"};

    private Animator _animator;
    private int _lastDirection;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    public int SetDirection(Vector2 direction)
    {
        string[] directionArray = null;

        //If player is nto moving
        /*if (direction.magnitude < .01f)
        {
            directionArray = staticDirections;
        }
        else
        {
            directionArray = runDirections;
            _lastDirection = DirectionToIndex(direction, 4);
        }*/
        directionArray = staticDirections;
        _lastDirection = DirectionToIndex(direction, 8);
        //Debug.Log(_lastDirection);
        _animator.Play(directionArray[_lastDirection]);
        return _lastDirection;
    }

    /**
     * Converts a Vector 2 direction in a slice around a circle int sliceCount pieces.
     */
    public static int DirectionToIndex(Vector2 dir, int sliceCount)
    {
        Vector2 normDir = dir.normalized;
        float step = 360f / sliceCount;
        float halfStep = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        angle += halfStep;

        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
    
}