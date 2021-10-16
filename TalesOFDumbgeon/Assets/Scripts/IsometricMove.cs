using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMove : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Sprite[] _sprites;
    
    private Rigidbody2D _playerRb;
    private SpriteRenderer _spriteRenderer;
    private InputControler _inputControler;
    private Vector2 _direccion;
    private IsometricCharacterRenderer _isoRenderer;
    private bool _moving = false;
    private void Awake()
    {
        _isoRenderer = gameObject.GetComponent<IsometricCharacterRenderer>();
        _playerRb = gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
        Vector2 output = Vector2.zero;
        if (input.x > 0.6 && input.y < 0.1 && input.y > -0.1)
        {
            output.x = 1f;
            output.y = -0.57735f;
            return output;
        }
        if (input.x < -0.6 && input.y < 0.1 && input.y > -0.1)
        {
            output.x = -1f;
            output.y = 0.57735f;
            return output;
        }
        if (input.y > 0.6 && input.x < 0.1 && input.x > -0.1)
        {
            output.x = 1f;
            output.y = 0.57735f;
            return output;
        }
        if (input.y < -0.6 && input.x < 0.1 && input.x > -0.1)
        {
            output.x = -1f;
            output.y = -0.57735f;
            return output;
        }
        if (input.y > 0.1 && input.x > 0.1)
        {
            output.x = 1f;
            output.y = 0f;
            return output;
        }
        if (input.y > 0.1 && input.x < -0.1)
        {
            output.x = 0f;
            output.y =  1f;
            return output;
        }
        if (input.y < -0.1 && input.x > 0.1)
        {
            output.x = 0f;
            output.y = -1f;
            return output;
        }
        if (input.y < -0.1 && input.x < -0.1)
        {
            output.x = -1f;
            output.y = 0f;
            return output;
        }
        return input;
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
