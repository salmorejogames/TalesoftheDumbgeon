using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMindController : Mind
{
    public static int NumBaseActions = 4;
    private static bool _playerDetected;
    private Transform _player;
    public float visionRange;
    public float cansancio;
    [SerializeField] private float maxDistancePlayer = 4f;
    [SerializeField] private float minDistancePlayer = 0.25f;
    [SerializeField] private float maxTired = 20f;
    [SerializeField] private float inercia = 0.2f;
    public EnemyIdle idleMind;
    public Mind attackMind;
    public Mind healhMind;
    public Mind retreatMind;
    
    private float _playerDetectedValue;
    private float _tiredValue;
    private float _playerDistanceValue;
    private float _lifeValue;
    private float _stasisValue;
    private  float[] _actions = new float[NumBaseActions];

    public bool debug = false;
    private DebugText _textDebug;
    private int lastAction = 0;
    private int lastState = 0;

    public enum EnemyBaseActions
    {
        Idle,
        Run,
        Heal,
        Attack,
        Wandering,
        Talking,
        Sleeping,
        GoBackHome,
        RunFromPlayer,
        HealAction,
        AttackAction,
        GetCloser,
        Formation,
        BrokeFormation,
        Descanso,
        None
    }
    private void Start()
    {
        _textDebug = FindObjectOfType<DebugText>();
        _playerDetected = false;
        _player = SingletoneGameController.PlayerActions.player.gameObject.transform;
    }

    public override int GetAction()
    {
        UpdateVariables();
        switch ((EnemyBaseActions) GetNewAction())
        {
            case EnemyBaseActions.Idle:
                lastAction = idleMind.GetAction();
                lastState = 0;
                break;
            case EnemyBaseActions.Attack:
                lastAction = attackMind.GetAction();
                lastState = 3;
                break;
            case EnemyBaseActions.Heal:
                lastAction = healhMind.GetAction();
                lastState = 2;
                break;
            case EnemyBaseActions.Run:
                lastAction = retreatMind.GetAction();
                lastState = 1;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return lastAction;
    }
    
    private int GetNewAction()
    {
        //float[] actions = new float[ATTACKS];
       
        _actions[0] = 1f-_playerDetectedValue;
        _actions[1] = (0.3f*(1-_stasisValue) + 0.7f*_tiredValue);
        _actions[2] = 0.3f*(1-_stasisValue) + 0.7f*(1-_lifeValue);
        _actions[3] = 0.6f + 0.2f * _stasisValue + 0.2f * (1 - _playerDistanceValue);
        _actions[lastState] += inercia;
        return  Array.IndexOf(_actions, _actions.Max());
    }

    private void Update()
    {
        if (!_playerDetected)
        {
            if (Vector3.Distance(body.gameObject.transform.position, _player.position) <=
                visionRange)
            {
                //RaycastHit2D raycastHit2D = Physics2D.Raycast(body.gameObject.transform.position, (_player.gameObject.transform.position - body.transform.position).normalized, visionRange);
                Debug.Log("Player detected");
                _playerDetected = true;
            }
        }
    }

    private void LateUpdate()
    {
        if (debug)
        {
            string addText = body.gameObject.name + ": [Stasis " + String.Format("{0:0.00}", _stasisValue ) + " Tired: " + String.Format("{0:0.00}", _tiredValue ) + " Heal: " + String.Format("{0:0.00}", _lifeValue ) + " PlayerDistance: " + String.Format("{0:0.00}", _playerDistanceValue ) + "]\n";
            addText+= EnemyBaseActions.Idle + ": " + _actions[0] + "\n";
            addText+= EnemyBaseActions.Run + ": " + _actions[1]+ "\n";
            addText+= EnemyBaseActions.Heal + ": " +_actions[2]+ "\n";
            addText+= EnemyBaseActions.Attack + ": " + _actions[3]+ "\n";
            addText += "LastAction: " + (EnemyBaseActions) lastAction + "\n";
            _textDebug.AddText(addText);
        }
    }

    public void UpdateTired(float amount)
    {
        cansancio += amount;
        cansancio = Mathf.Clamp(cansancio, 0, maxTired);
    }

    private void UpdateVariables()
    {
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
        }
        _lifeValue = body.stats.GetActualHealth() / body.stats.maxHealth;
        _stasisValue = (body.stasis + 1)/2;
        
        _tiredValue = cansancio / maxTired;
        _playerDetectedValue = _playerDetected ? 1 : 0;
    }
    
}
