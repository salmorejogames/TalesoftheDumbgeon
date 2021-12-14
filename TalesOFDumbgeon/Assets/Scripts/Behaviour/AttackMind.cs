using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMind : Mind
{
    [SerializeField] private float highStasis;
    [SerializeField] private float lowStasis;
    [SerializeField] private float attackTime;
    [SerializeField] private float attackRange;

    private Transform _player;
    private float _timer;

    private void Start()
    {
        _timer = attackTime;
        _player = SingletoneGameController.PlayerActions.player.transform;
    }

    private void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;
    }

    public override int GetAction()
    {
        Vector3 pos = body.gameObject.transform.position;
        if (_timer <= 0)
        {
            if (Vector3.Distance(pos, _player.position) < attackRange)
            {
                _timer = attackTime;
                return (int) EnemyMindController.EnemyBaseActions.AttackAction;
            }
            return (int) EnemyMindController.EnemyBaseActions.GetCloser;
        }
        if(body.stasis>highStasis)
            return (int) EnemyMindController.EnemyBaseActions.BrokeFormation;
        if(body.stasis < lowStasis)
            return (int) EnemyMindController.EnemyBaseActions.RunFromPlayer;
        return (int) EnemyMindController.EnemyBaseActions.Formation;
    }
}
