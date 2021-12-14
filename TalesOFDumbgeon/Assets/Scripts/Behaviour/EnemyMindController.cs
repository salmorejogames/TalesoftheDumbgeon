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

    public EnemyIdle idleMind;
    public Mind attackMind;
    public Mind healhMind;
    public Mind retreatMind;
    
    private float _playerDetectedValue;
    private float _tiredValue;
    private float _playerDistanceValue;
    private float _lifeValue;
    private float _stasisValue;

    public bool debug = false;
    private DebugText _textDebug;
    private int lastAction = 0;

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
                break;
            case EnemyBaseActions.Attack:
                lastAction = attackMind.GetAction();
                break;
            case EnemyBaseActions.Heal:
                lastAction = healhMind.GetAction();
                break;
            case EnemyBaseActions.Run:
                lastAction = retreatMind.GetAction();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return lastAction;
    }
    
    private int GetNewAction()
    {
        //float[] actions = new float[ATTACKS];
        float[] actions = new float[NumBaseActions];
        actions[0] = 1f-_playerDetectedValue;
        actions[1] = 0.3f*(1-_stasisValue) + 0.7f*_tiredValue;
        actions[2] = 0.3f*(1-_stasisValue) + 0.7f*(1-_lifeValue);
        actions[3] = 0.4f + 0.3f * _stasisValue + 0.3f * (1 - _playerDistanceValue);
        return  Array.IndexOf(actions, actions.Max());
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
            addText+= EnemyBaseActions.Idle + ": " + (1f-_playerDetectedValue)+ "\n";
            addText+= EnemyBaseActions.Run + ": " + (0.3f*(1-_stasisValue) + 0.7f*_tiredValue)+ "\n";
            addText+= EnemyBaseActions.Heal + ": " + ( 0.3f*(1-_stasisValue) + 0.7f*(1-_lifeValue))+ "\n";
            addText+= EnemyBaseActions.Attack + ": " + (0.4f + 0.3f * _stasisValue + 0.3f * (1 - _playerDistanceValue))+ "\n";
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
