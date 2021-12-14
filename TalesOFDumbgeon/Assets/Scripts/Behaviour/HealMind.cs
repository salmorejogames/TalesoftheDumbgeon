using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMind : Mind
{
    [SerializeField] private Mind runMind;
    [SerializeField] private float healTime;
    [SerializeField] private float closePlayerDistance = 0.75f;
    private Transform _player;
    private float _time;

    private void Start()
    {
        _player = SingletoneGameController.PlayerActions.player.gameObject.transform;
        _time = healTime;
    }

    private void Update()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
        }
    }

    public override int GetAction()
    {
        if (Vector3.Distance(body.gameObject.transform.position, _player.position) > closePlayerDistance && _time <= 0)
        {
            _time = healTime;
            return (int) EnemyMindController.EnemyBaseActions.HealAction;
        }
        return runMind.GetAction();
    }
}
