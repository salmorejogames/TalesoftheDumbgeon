using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMove : MonoBehaviour, IMovil
{
    private const float ORIENTATION_STEP = 45f;
    private const float ORIENTATION_STEP_SMALL = 30f;
    private const float ORIENTATION_STEP_BIG = 60f;
    private const float ORIENTATION_OFFSET = 90f;

    [NonSerialized] public PlayerActionsController PlayerActions;
    [NonSerialized] public CharacterStats Stats;
    [NonSerialized] public float angle = 0;
    [NonSerialized] public bool canMove = true;

    private Rigidbody2D _playerRb;
    private InputControler _inputControler;
    private IsometricCharacterRenderer _isoRenderer;

    public IsometricCharacterRenderer IsoRenderer => _isoRenderer;

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
            Move();          
        }else
        {
            _isoRenderer.animatorController.SetMoving(false);
        }
        
        PlayerActions.UpdateWeaponPosition(angle);
    }

    private bool CanMove()
    {
        return canMove;
    }

    public void UpdateAngle(Vector2 movement)
    {
        int direction = _isoRenderer.SetDirection(movement);
        switch (direction)
        {
            //CASE N, W, E, S
            case 0:
            case 2:
            case 4:
            case 6:
                angle = direction * ORIENTATION_STEP + ORIENTATION_OFFSET;
                break;
            //CASE NE, SW
            case 1:
            case 5:
                angle = (direction - 1) * ORIENTATION_STEP + ORIENTATION_OFFSET  + ORIENTATION_STEP_BIG;
                break;
            //CASE NW, SE
            default:
                angle = (direction - 1) * ORIENTATION_STEP + ORIENTATION_OFFSET  + ORIENTATION_STEP_SMALL;
                break;
        }
    }
    
    public void Move()
    {
        Vector2 _direccion = _inputControler.Jugador.Move.ReadValue<Vector2>();
        if (_direccion.magnitude > 0.01f )
        {
            Vector2 movement = IsometricUtils.AxisToIsometric(_direccion);//IsometricUtils.CartesianToIsometric(_direccion);
            Vector3 step = movement * (Stats.GetSpeedValue() * Time.fixedDeltaTime);
            _playerRb.MovePosition((gameObject.transform.position + step));
            UpdateAngle(movement);
            _isoRenderer.animatorController.SetMoving(true);
        }
        else
        {
            _isoRenderer.animatorController.SetMoving(false);
        }
    }

    public void DisableMovement(float time)
    {
        SingletoneGameController.PlayerActions.DisableMovement(time);
    }

    private void OnEnable()
    {
        _inputControler.Enable();
    }

    private void OnDisable()
    {
        _inputControler.Disable();
    }

    public void EnableInputController()
    {
        _inputControler.Enable();
        SingletoneGameController.PlayerActions.EnableMovement();
    }

    public void DisableInputController()
    {
        _inputControler.Disable();
        SingletoneGameController.PlayerActions.DisableMovement();
    }


}
