using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEditor.UIElements;
using UnityEngine;

public class ExampleEnemyBehaviour : MonoBehaviour, IDeadable
{
    private SpriteRenderer _spr;
    private IsometricMove _player;
    public float speed;

    private void Update()
    {
        if(_player==null)
            _player = SingletoneGameController.PlayerActions.player;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _player.transform.position, speed*Time.deltaTime);
    }

    private void Start()
    {
        _spr = gameObject.GetComponent<SpriteRenderer>();
        _player = SingletoneGameController.PlayerActions.player;
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    public void Damage(GameObject enemy, float cantidad)
    {
        if(cantidad<0.99f)
            _spr.color = Color.cyan;
        else if(cantidad<2f)
            _spr.color = Color.yellow;
        else 
            _spr.color = Color.red;
        Invoke(nameof(RevertColor), 0.2f);
    }

    public void RevertColor()
    {
        _spr.color = Color.white;
    }
}
