using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyActions : MonoBehaviour
{
    [SerializeField] private EnemyMindController mind;
    [SerializeField] private BaseEnemy enemy;
    [SerializeField] private float wanderingDistance = 3f;
    [SerializeField] private float midDistance = 1.2f;
    [SerializeField] private DamageNumber numbers;
    public NavMeshAgent agent;
    private EnemyMindController.EnemyBaseActions _action;
    private Generator _generator;
    private Coroutine _actualCoroutine;
    private Transform _player;
    private float angle;

    [SerializeField] private ImageCanvas imageCanvas;
    [Header("Iconos")]
    [SerializeField] private Sprite dialogue;
    [SerializeField] private Sprite sleep;
    [SerializeField] private Sprite heal;
    [SerializeField] private Sprite rest;
    [SerializeField] private Sprite wandering;
    [SerializeField] private Sprite run;
    [SerializeField] private Sprite detected;

    private bool runTrigger = false;
    private bool detectedTrigger = false;
    private void Start()
    {
        _player = SingletoneGameController.PlayerActions.player.gameObject.transform;
        _actualCoroutine = null;
        _action = EnemyMindController.EnemyBaseActions.None;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        _generator = mind.idleMind.GetHome();
        float step = 360f / _generator.GetNumEnemys();
        angle = step * mind.idleMind.GetIndex() * step;
    }

    private void Update()
    {
        EnemyMindController.EnemyBaseActions newAction = (EnemyMindController.EnemyBaseActions) mind.GetAction();
        if (newAction != _action)
        {
            agent.destination = enemy.gameObject.transform.position;
            agent.stoppingDistance = 0f;
            agent.speed = enemy.stats.GetSpeedValue();
            if (_actualCoroutine != null)
            {
                StopCoroutine(_actualCoroutine);
                _actualCoroutine = null;
            }
            _action = newAction;
            MakeAction();
        }
    }

    private void MakeAction()
    {
        Debug.LogWarning(_action);
        if (runTrigger && _action != EnemyMindController.EnemyBaseActions.GoBackHome &&
            _action != EnemyMindController.EnemyBaseActions.RunFromPlayer)
            runTrigger = false;
        if (!detectedTrigger && _action != EnemyMindController.EnemyBaseActions.Wandering &&
            _action != EnemyMindController.EnemyBaseActions.Sleeping &&
            _action != EnemyMindController.EnemyBaseActions.Talking)
        {
            detectedTrigger = true;
            GenerateEmote(detected);
        }
        switch (_action)
        {
            case EnemyMindController.EnemyBaseActions.None:
            case EnemyMindController.EnemyBaseActions.Idle:
            case EnemyMindController.EnemyBaseActions.Attack:
            case EnemyMindController.EnemyBaseActions.Heal:
            case EnemyMindController.EnemyBaseActions.Run:
                Debug.LogError("Algo ha ido mal en las acciones de " + gameObject.name);
                break;
            case EnemyMindController.EnemyBaseActions.Wandering:
                
                _actualCoroutine = StartCoroutine(WanderingAction());
                break;
            case EnemyMindController.EnemyBaseActions.Talking:
                _actualCoroutine = StartCoroutine(Talking());
                break;
            case EnemyMindController.EnemyBaseActions.Sleeping:
                _actualCoroutine = StartCoroutine(Sleeping());
                break;
            case EnemyMindController.EnemyBaseActions.GoBackHome:
                if (!runTrigger)
                {
                    runTrigger = true;
                    GenerateEmote(run);
                }
                agent.SetDestination(_generator.gameObject.transform.position);
                break;
            case EnemyMindController.EnemyBaseActions.RunFromPlayer:
                _actualCoroutine = StartCoroutine(RuningAway());
                break;
            case EnemyMindController.EnemyBaseActions.HealAction:
                HealhAction();
                break;
            case EnemyMindController.EnemyBaseActions.AttackAction:
                mind.UpdateTired(2);
                enemy.Attack();
                break;
            case EnemyMindController.EnemyBaseActions.GetCloser:
                _actualCoroutine = StartCoroutine(GettingCloser());
                break;
            case EnemyMindController.EnemyBaseActions.Formation:
                _actualCoroutine = StartCoroutine(Formation());
                break;
            case EnemyMindController.EnemyBaseActions.BrokeFormation:
                agent.stoppingDistance = 0.5f;
                _actualCoroutine = StartCoroutine(GettingCloser());
                break;
            case EnemyMindController.EnemyBaseActions.Descanso:
                _actualCoroutine = StartCoroutine(Descanso());
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void HealhAction()
    {
        GenerateEmote(heal);
        mind.UpdateTired(-20f);
        float healing = enemy.stats.maxHealth / 4f;
        agent.destination = gameObject.transform.position;
        enemy.stats.Heal(healing);
        DamageNumber dmgN = Instantiate(numbers, transform.position, Quaternion.identity);
        dmgN.Inicializar(healing, transform);
        dmgN.number.color = Color.green;
    }

    private IEnumerator WanderingAction()
    {
        agent.destination = enemy.gameObject.transform.position + (Vector3) Random.insideUnitCircle*wanderingDistance;
        GenerateEmote(wandering);
        yield return new WaitForSeconds(3f);
        agent.destination = _generator.gameObject.transform.position;
        yield return new WaitForSeconds(3.2f);
        _generator.ChangeCentinel();
        _action = EnemyMindController.EnemyBaseActions.None;
    }

    private IEnumerator Talking()
    {
        while (true)
        {
            Debug.Log(gameObject.name + ": talking");
            GenerateEmote(dialogue);
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
        
    }

    private IEnumerator Sleeping()
    {
        while (true)
        {
            Debug.Log(gameObject.name + ": Sleeping");
            GenerateEmote(sleep);
            yield return new WaitForSeconds(Random.Range(3f, 6f));
        }
    }
    
    private IEnumerator RuningAway()
    {
        if (!runTrigger)
        {
            runTrigger = true;
            GenerateEmote(run);
        }
        while (true)
        {
            var pos = enemy.gameObject.transform.position;
            var playerPosition = _player.position;
            var heading = pos - playerPosition;
            mind.UpdateTired(Time.fixedDeltaTime);
            agent.destination = playerPosition + (heading / heading.magnitude) * wanderingDistance;
            yield return new WaitForFixedUpdate();
        }
    }
    
    private IEnumerator GettingCloser()
    {
        while (true)
        {
            agent.destination = _player.position;
            mind.UpdateTired(Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
    
    private IEnumerator Formation()
    {
        while (true)
        {
            double radians = Math.PI * angle / 180.0f; 
            agent.destination = _player.position + new Vector3(midDistance* (float) Math.Sin(radians), midDistance* (float) Math.Cos(radians), 0);
            mind.UpdateTired(Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator Descanso()
    {
        GenerateEmote(rest);
        while (true)
        {
            mind.UpdateTired(-1f);
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void GenerateEmote(Sprite sprite)
    {
        ImageCanvas newCanvas = Instantiate(imageCanvas, gameObject.transform.position, Quaternion.identity, this.transform);
        newCanvas.Inicializar(sprite, gameObject.transform);
    }
}
