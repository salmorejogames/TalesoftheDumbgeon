using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class IsometricCharacterRenderer : MonoBehaviour
{
    
    private const int SliceCount = 8;
    [SerializeField] public PlayerAnimationController animatorController;
    private int _lastDirection;

    public int SetDirection(Vector2 direction)
    {
        //string[] directionArray = null;
        //If player is nto moving
        /*
        else
        {
            directionArray = runDirections;
            _lastDirection = DirectionToIndex(direction, 4);
        }*/
        //directionArray = staticDirections;
        int newDirection = DirectionToIndex(direction, SliceCount);
        if(newDirection != _lastDirection)
            animatorController.ChangeAnimation((BodyParts.Direction)((newDirection+2)%8));
        //Debug.Log(_lastDirection);
        _lastDirection = newDirection;
        //_animator.Play(directionArray[_lastDirection]);
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
