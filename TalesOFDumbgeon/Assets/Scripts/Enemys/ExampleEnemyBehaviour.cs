using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

public class ExampleEnemyBehaviour : BaseEnemy, IDeadable
{

   

    private SpriteRenderer _spr;
    private IsometricMove _player;
    [SerializeField] private NavMeshAgent agent;

    [SerializeField]
    private DamageNumber DmgPrefab;

    private void Update()
    {
        if (!SingletoneGameController.PlayerActions.dead)
        {
            if(_player==null)
                _player = SingletoneGameController.PlayerActions.player;
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _player.transform.position, stats.GetSpeedValue()*Time.deltaTime);
            agent.destination = _player.transform.position;
            
        }
    }

    private void Awake()
    {
        stats = gameObject.GetComponent<CharacterStats>();
        _spr = gameObject.GetComponent<SpriteRenderer>();
        _player = SingletoneGameController.PlayerActions.player;
        agent.updateUpAxis = false;
        agent.speed = stats.GetSpeedValue();
        agent.updateRotation = false;
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public void Damage(Vector3 enemyPos, float cantidad, Elements.Element element)
    {

        audio.Play();

        float multiplier = Elements.GetElementMultiplier(element, stats.element);
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

    public int GetDifficulty()
    {
        return difficulty;
    }
}
