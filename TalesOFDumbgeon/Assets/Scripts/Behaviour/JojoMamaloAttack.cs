using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class JojoMamaloAttack : Mind
{

    [SerializeField] private float minDistancePlayer;
    [SerializeField] private float maxDistancePlayer;

    private const int ATTACKS = 11;

    private Transform _player;
    private DebugText _debugText;

    public bool debugMode = false;
    [NonSerialized] public JojoMamaloMind Mind;

    private float _playerDistanceValue;
    private float _lifeUntilPhaseValue;
    private float _extasisValue;
    private float _stage2;
    private float _stage3;
    private float _fear;

    private void Start()
    {
       _player = SingletoneGameController.PlayerActions.player.gameObject.transform;
       
        _stage2 = 0;
        _stage3 = 0;
        _debugText = FindObjectOfType<DebugText>();
    }
    public override int GetAction()
    {
        UpdateValues();
        return GetAttack();
    }

    private void Update()
    {
        if (debugMode)
        {
            UpdateValues();
            //float[] actions = new float[ATTACKS];
            float[] actions = new float[ATTACKS];
            const int enumOffset = (int) Actions.JojoActions.CaC;
            actions[0] = IsFurious() * (1 - _playerDistanceValue);
            actions[1] = (1 - _playerDistanceValue) * 0.8f;
            actions[2] = _playerDistanceValue * 0.8f;
            actions[3] = (1 - _playerDistanceValue) * 0.75f;
            actions[4] = _fear * IsFeared();
            actions[5] = _stage2*actions[0];
            actions[6] = _playerDistanceValue * _stage2 * 0.8f;
            actions[7] = actions[4] * _stage2;
            actions[8] = (_fear * _stage3 * (_extasisValue <= Mind.MAXStasis ? 1 : 0));
            actions[9] = (1 - _lifeUntilPhaseValue) * _stage3;
            actions[10] = actions[9] * IsFeared();
            string text = "Stasis: " +String.Format("{0:0.000}", body.stasis) + "\n";
            for(int i = 0; i < actions.Length; i++)
                text += "- " +((Actions.JojoActions) enumOffset + i).ToString() + ": " + String.Format("{0:0.00}", actions[i] )+ "\n";
            _debugText.SetText(text);
        }
    }

    private void UpdateValues()
    {
        //Update _playerDistance (0-1)
        float distance = Vector3.Distance(_player.position, body.gameObject.transform.position);
        if (distance <= minDistancePlayer)
            _playerDistanceValue = 0;
        else if (distance >= maxDistancePlayer)
            _playerDistanceValue = 1;
        else
        {
            float distanceSegment = maxDistancePlayer - minDistancePlayer;
            float percentSegment = distance - minDistancePlayer;
            _playerDistanceValue = percentSegment/distanceSegment;
            Debug.Log(_playerDistanceValue);
        }
        
        //Update Stage
        _stage2 = Mind.Stage >= 1 ? 1 : 0;
        _stage3 = Mind.Stage >= 2 ? 1 : 0;

        //Update Life until next Stage
        float actualHealth = body.stats.GetActualHealth();
        float maxHealth;
        if (Mind.Stage == 0)
            maxHealth = body.stats.maxHealth;
        else
            maxHealth = Mind.HealthStages[Mind.Stage - 1];
        float healthSegment = maxHealth - Mind.HealthStages[Mind.Stage];
        float percentHealthSegment = actualHealth - Mind.HealthStages[Mind.Stage];
        _lifeUntilPhaseValue = percentHealthSegment/healthSegment;
        
        //Update Extasis
        _extasisValue = body.stasis;

        //Update Fear
        _fear = (1 - _playerDistanceValue) * 0.7f + (1 - _lifeUntilPhaseValue) * 0.3f;

    }

    private int GetAttack()
    {
        //float[] actions = new float[ATTACKS];
        float[] actions = new float[ATTACKS];
        const int enumOffset = (int) Actions.JojoActions.CaC;

        actions[0] = IsFurious() * (1 - _playerDistanceValue) + RandomValue();
        actions[1] = (1 - _playerDistanceValue) * 0.8f + RandomValue();
        actions[2] = _playerDistanceValue * 0.8f + RandomValue();
        actions[3] = (1 - _playerDistanceValue) * 0.75f + RandomValue();
        actions[4] = _fear * IsFeared();
        actions[5] = _stage2*actions[0]  + RandomValue();
        actions[6] = _playerDistanceValue * _stage2 * 0.8f + RandomValue();
        actions[7] = actions[4] * _stage2 + RandomValue();
        actions[8] = (_fear * _stage3 * (_extasisValue <= Mind.MAXStasis ? 1 : 0)) + RandomValue();
        actions[9] = (1 - _lifeUntilPhaseValue) * _stage3;
        actions[10] = actions[9] * IsFeared() + RandomValue();
        for(int i = 0; i < actions.Length; i++)
            Debug.Log(((Actions.JojoActions) enumOffset + i).ToString() + ": " + actions[i]);
        return enumOffset + Array.IndexOf(actions, actions.Max());
    }

    private float RandomValue()
    {
        return Random.Range(-0.1f, 0.1f);
    }
    private int IsFeared()
    {
        return _extasisValue <= Mind.MINStasis ? 1 : 0;
    }
    
    private int IsFurious()
    {
        return _extasisValue >= Mind.MAXStasis ? 1 : 0;
    }

}
