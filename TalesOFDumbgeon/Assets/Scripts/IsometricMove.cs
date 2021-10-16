using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMove : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float gapX;

    private Rigidbody2D _playerRb;
    private InputControler _inputControler;
    private Vector2 _direccion;
    private IsometricCharacterRenderer _isoRenderer;
    private bool _moving = false;
    private void Awake()
    {
        _isoRenderer = gameObject.GetComponent<IsometricCharacterRenderer>();
        _playerRb = gameObject.GetComponent<Rigidbody2D>();
        _inputControler = new InputControler();
        _inputControler.Jugador.Move.started += ctx => SetMoving(true);
        _inputControler.Jugador.Move.canceled += ctx => SetMoving(false);
    }


    void FixedUpdate()
    {
        if (_moving)
        {
            _direccion = _inputControler.Jugador.Move.ReadValue<Vector2>();
            Vector2 currentPos = _playerRb.position;
            Vector2 movement = (ConvertToIsometric(_direccion) * speed);
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            _isoRenderer.SetDirection(movement);
            _playerRb.MovePosition(newPos);
        }
        //Moverse();
    }

    private Vector2 ConvertToIsometric(Vector2 input)
    {
        float newX = input.x - input.y;
        if (newX > 0.1)
            newX += gapX;
        if (newX < -0.1)
            newX -= gapX;
            
        return new Vector2(newX , -(-input.x - input.y )/2 );
    }

    private void SetMoving(bool move)
    {
        _moving = move;
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
