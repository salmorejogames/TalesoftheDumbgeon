﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMove : MonoBehaviour
{


    [SerializeField] private float gapX;

    private const float ORIENTATION_STEP = 45f;
    private const float ORIENTATION_OFFSET = 90f;  
    
    public float angle = 0;
    private Rigidbody2D _playerRb;
    private InputControler _inputControler;
    [NonSerialized] public PlayerActionsController PlayerActions;
    [NonSerialized] public CharacterStats Stats;
    private Vector2 _direccion;
    private IsometricCharacterRenderer _isoRenderer;
    private bool _active = true;
    public bool canMove = true;
    private Vector3 _objetive;
    private float _transitionSpeed;
    private void Awake()
    {
        _isoRenderer = gameObject.GetComponent<IsometricCharacterRenderer>();
        _playerRb = gameObject.GetComponent<Rigidbody2D>();
        PlayerActions = gameObject.GetComponent<PlayerActionsController>();
        Stats = gameObject.GetComponent<CharacterStats>();
        _inputControler = new InputControler();
    }
    
    void FixedUpdate()
    {
        if (CanMove())
        {
        
                _direccion = _inputControler.Jugador.Move.ReadValue<Vector2>();
                if (!_direccion.Equals(Vector2.zero))
                {
                    Vector2 movement = (ConvertToIsometric(_direccion));
                    Vector3 step = movement * (Stats.speed * Time.fixedDeltaTime);
                    _playerRb.MovePosition((gameObject.transform.position + step));
                    UpdateAngle(movement);
                }
        }
        PlayerActions.UpdateWeaponPosition(angle);
    }

    private bool CanMove()
    {
        return _active && canMove;
    }

    public void UpdateAngle(Vector2 movement)
    {
        angle = _isoRenderer.SetDirection(movement) * ORIENTATION_STEP + ORIENTATION_OFFSET;
    }

    private Vector2 ConvertToIsometric(Vector2 input)
    {
        Vector2 output = IsometricUtils.CartesianToIsometric(input);
        if (output.x > 0.1)
            output.x += gapX;
        if (output.x < -0.1)
            output.x -= gapX;
        
        return output;
    }

    public void SetActive(bool active)
    {
        _active = active;
    }
    
    private void OnEnable()
    {
        _inputControler.Enable();
    }

    private void OnDisable()
    {
        _inputControler.Disable();
    }
    
}
