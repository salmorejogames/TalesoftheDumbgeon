﻿using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEditor.UIElements;
using UnityEngine;

public class ExampleEnemyBehaviour : MonoBehaviour, IDeadable
{
    private SpriteRenderer _spr;
    private IsometricMove _player;
    private CharacterStats _stats;

    [SerializeField]
    private DamageNumber DmgPrefab;

    private void Update()
    {
        if (!SingletoneGameController.PlayerActions.dead)
        {
            if(_player==null)
                _player = SingletoneGameController.PlayerActions.player;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _player.transform.position, _stats.speed*Time.deltaTime);
        }
    }

    private void Start()
    {
        _stats = gameObject.GetComponent<CharacterStats>();
        _spr = gameObject.GetComponent<SpriteRenderer>();
        _player = SingletoneGameController.PlayerActions.player;
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public void Damage(Vector3 enemyPos, float cantidad, Elements.Element element)
    {
        float multiplier = Elements.GetElementMultiplier(element, _stats.element);
        DamageNumber dmgN = Instantiate(DmgPrefab, transform.position, Quaternion.identity);
        dmgN.Inicializar(cantidad, transform);
        if(multiplier>1.1f)
            _spr.color = Color.red;
        else if(multiplier<0.9f)
            _spr.color = Color.cyan;
        else 
            _spr.color = Color.yellow;
        dmgN.number.color = _spr.color;
        Invoke(nameof(RevertColor), 0.2f);
    }

    public void RevertColor()
    {
        _spr.color = Color.white;
    }
}