using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMindController : Mind
{
    private static bool _playerDetected;
    private CharacterStats _player;
    public float visionRange;
    public float cansancio;
    private void Start()
    {
        _playerDetected = false;
        _player = SingletoneGameController.PlayerActions.player.Stats;
    }

    public override int GetAction()
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        if (!_playerDetected)
        {
            if (Vector3.Distance(body.gameObject.transform.position, _player.gameObject.transform.position) <=
                visionRange)
            {
                //RaycastHit2D raycastHit2D = Physics2D.Raycast(body.gameObject.transform.position, (_player.gameObject.transform.position - body.transform.position).normalized, visionRange);
                Debug.Log("Player detected");
                _playerDetected = true;
            }
        }
    }

    private void UpdateVariables()
    {
        
    }
    
}
