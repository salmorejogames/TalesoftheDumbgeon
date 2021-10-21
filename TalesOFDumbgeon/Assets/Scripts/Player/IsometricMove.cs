using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMove : MonoBehaviour
{

    public float speed;
    [SerializeField] private float gapX;

    private const float ORIENTATION_STEP = 45f;
    private const float ORIENTATION_OFFSET = 90f;  
    
    public float angle = 0;
    private Rigidbody2D _playerRb;
    private InputControler _inputControler;
    private PlayerActionsController _playerActions;
    private Vector2 _direccion;
    private IsometricCharacterRenderer _isoRenderer;
    private bool _moving = false;
    private bool _active = true;
    private Vector3 _objetive;
    private float _transitionSpeed;
    private void Awake()
    {
        _isoRenderer = gameObject.GetComponent<IsometricCharacterRenderer>();
        _playerRb = gameObject.GetComponent<Rigidbody2D>();
        _playerActions = gameObject.GetComponent<PlayerActionsController>();
        _inputControler = new InputControler();
        _inputControler.Jugador.Move.started += ctx => SetMoving(true);
        _inputControler.Jugador.Move.canceled += ctx => SetMoving(false);
    }


    void FixedUpdate()
    {
        if (CanMove())
        {
            _direccion = _inputControler.Jugador.Move.ReadValue<Vector2>();
            Vector2 movement = (ConvertToIsometric(_direccion));
            _playerRb.velocity = movement  * speed;
            UpdateAngle(movement);
        }
        
        //Debug.Log(angle);
        //Moverse();
    }

    private bool CanMove()
    {
        return _moving && _active && _playerActions.active;
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

    private void SetMoving(bool move)
    {
        _moving = move;
        if(!move)
            _playerRb.velocity = Vector2.zero;
    }

    public void SetActive(bool active)
    {
        _active = active;
        _playerRb.velocity = Vector2.zero;
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
