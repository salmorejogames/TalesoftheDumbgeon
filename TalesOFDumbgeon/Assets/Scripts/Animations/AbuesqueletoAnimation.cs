using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbuesqueletoAnimation : MonoBehaviour
{
    [SerializeField] private Animator north;
    [SerializeField] private Animator south;
    [SerializeField] private Animator east;
    [SerializeField] private Animator west;
    [SerializeField] private Animator nEast;
    [SerializeField] private Animator nWest;
    [SerializeField] private Animator sEast;
    [SerializeField] private Animator sWest;

    private BodyParts.Direction _direction;
    private Animator _current;
    private bool _moving;
    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Start()
    {
        _moving = false;
        _current = south;
        _current.gameObject.SetActive(true);
        _direction = BodyParts.Direction.South;
    }

    public void SetMoving(bool moving)
    {
        _moving = moving;
        _current.SetBool(Walk, _moving);
    }

    public void StartAtack()
    {
        _current.SetTrigger(Attack);
    }
    
    public void UpdateDirection(float angle)
    {
        angle = angle % 360;
        if (angle < 0)
            angle += 360;
        if (angle < 30 || angle > 330)
        {
            if (_direction == BodyParts.Direction.East) return;
            _direction = BodyParts.Direction.East;
            _current.gameObject.SetActive(false);
            _current = east;
            _current.gameObject.SetActive(true);
        }else if (angle < 60)
        {
            if (_direction == BodyParts.Direction.NorthEast) return;
            _direction = BodyParts.Direction.NorthEast;
            _current.gameObject.SetActive(false);
            _current = nEast;
            _current.gameObject.SetActive(true);
        }else if (angle < 120)
        {
            if (_direction == BodyParts.Direction.North) return;
            _direction = BodyParts.Direction.North;
            _current.gameObject.SetActive(false);
            _current = north;
            _current.gameObject.SetActive(true);
        }else if (angle < 150)
        {
            if (_direction == BodyParts.Direction.NorthWest) return;
            _direction = BodyParts.Direction.NorthWest;
            _current.gameObject.SetActive(false);
            _current = nWest;
            _current.gameObject.SetActive(true);
        }else if (angle < 210)
        {
            if (_direction == BodyParts.Direction.West) return;
            _direction = BodyParts.Direction.West;
            _current.gameObject.SetActive(false);
            _current = west;
            _current.gameObject.SetActive(true);
        }else if (angle < 240)
        {
            if (_direction == BodyParts.Direction.SouthWest) return;
            _direction = BodyParts.Direction.SouthWest;
            _current.gameObject.SetActive(false);
            _current = sWest;
            _current.gameObject.SetActive(true);
        }else if (angle < 315)
        {
            if (_direction == BodyParts.Direction.South) return;
            _direction = BodyParts.Direction.South;
            _current.gameObject.SetActive(false);
            _current = south;
            _current.gameObject.SetActive(true);
        }
        else
        {
            if (_direction == BodyParts.Direction.SouthEast) return;
            _direction = BodyParts.Direction.SouthEast;
            _current.gameObject.SetActive(false);
            _current = sEast;
            _current.gameObject.SetActive(true); 
        }

        _current.SetBool(Walk, _moving);
    }
    
    
    
    
    
}
