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
    
    public float angle = 0;
    private Rigidbody2D _playerRb;
    private InputControler _inputControler;
    private Vector2 _direccion;
    private IsometricCharacterRenderer _isoRenderer;
    private bool _moving = false;
    private Vector3 _objetive;
    private float _transitionSpeed;
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
            Vector2 movement = (ConvertToIsometric(_direccion));
            _playerRb.velocity = movement  * speed;
            angle = _isoRenderer.SetDirection(movement) * ORIENTATION_STEP + ORIENTATION_OFFSET;
            //Debug.Log(angle);
        }
        //Moverse();
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
    
    private void OnEnable()
    {
        _inputControler.Enable();
    }

    private void OnDisable()
    {
        _inputControler.Disable();
    }

    public void MoveTo(Vector3 destiny, float speed)
    {
        _moving = false;
        _objetive = destiny;
        _transitionSpeed = speed;
    }

    IEnumerator Transition()
    {
        while (Vector3.Distance(transform.position, _objetive) > 0.001)
        {
            transform.position = Vector3.MoveTowards(transform.position, _objetive, _transitionSpeed * Time.deltaTime);
            yield return null;
        }
        _moving = true;
    }
}
