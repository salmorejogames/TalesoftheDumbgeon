using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMove : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float gapX;

    private const float ORIENTATION_STEP = 45f;
    private const float ORIENTATION_OFFSET = 90f;  
    
    private float _angle = 0;
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
            //Vector2 currentPos = _playerRb.position;
            Vector2 movement = (ConvertToIsometric(_direccion));
           // Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            _playerRb.velocity = movement  * speed;
            _angle = _isoRenderer.SetDirection(movement) * ORIENTATION_STEP + ORIENTATION_OFFSET;
            //_playerRb.MovePosition(newPos);
            //Debug.Log(_angle);
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
        if(!move)
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
