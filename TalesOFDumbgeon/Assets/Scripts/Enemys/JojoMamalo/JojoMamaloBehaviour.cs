using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Interfaces;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class JojoMamaloBehaviour : BaseEnemy, IDeadable, IMovil
{
    [NonSerialized] public AudioSource audioSrc;
    public AudioClip Jojomamalo_Fight;
    [SerializeField] private JojoSounds sounds;

    public const int NumPositions = 4;
    private int _actualPos;
    private float _damageAcumulated = 0;
    private bool _active = true;
    private Transform _target;
    private Vector2[] _locations = new Vector2[NumPositions];
    private NavMeshAgent _navMeshAgent;
    private float _elapsedTime;
    public DamageNumber prefabDamage;
    public JojomamaloAnimationController animationController;
    private bool _combat;

    private Objetives _objetive;
    [NonSerialized] public bool invincible;
    public float attackCooldown;
    public float nearDistance;
    public float midDistance;
    public float farDistance;
    [SerializeField] private Weapon jojoarma;
    [SerializeField] private JojomaloSkills skills;
    
    //Dialogos
    private int run = 0;
    public DialogueTrigger dialogueTrigger;

    public JojoMamaloMind masterMind;

    private Actions.JojoActions _actualAction;

    public Vector3 TargetPos => _target.position;
    public int ActualPos => _actualPos;

    public float DamageAcumulated
    {
        get => _damageAcumulated;
        set => _damageAcumulated = value;
    }

    public Objetives Objetive
    {
        get => _objetive;
        set => _objetive = value;
    }

    public enum Objetives
    {
        Near,
        Mid,
        Far,
        None
    }
    void Awake()
    {
        _combat = false;
        _objetive = Objetives.None;
        _actualAction = Actions.JojoActions.Presentacion;
        invincible = true;
        audioSrc = GameObject.Find("GameManager").GetComponent<AudioSource>();
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _elapsedTime = 0;
        MapInstance map = SingletoneGameController.MapManager.ActualMap;
        stats = gameObject.GetComponent<CharacterStats>();
        _target = SingletoneGameController.PlayerActions.player.gameObject.transform;
        _locations[0] = new Vector2(map.dims[0]-4, 0);
        _locations[1] = new Vector2(map.dims[1]+4, 0);
        _locations[2] = new Vector2(0, map.dims[2]-2);
        _locations[3] = new Vector2(0, map.dims[3]+2);
        
        UpdatePosition(0);

        BaseWeapon newJojoArma = new RangedWeapon();
        newJojoArma.Randomize(1);
        newJojoArma.OnDamage = () => StasisActionUpdate(StasisActions.Impact, newJojoArma.Dmg);
        jojoarma.ChangeWeapon(newJojoArma);
        _navMeshAgent.speed = 0f;
        skills.ActivateSkill(_actualAction);
    }

    private void Start()
    {
        audioSrc.Stop();
        audioSrc.clip = Jojomamalo_Fight;
        audioSrc.Play();
        run = PlayerPrefs.GetInt("Jojomamalos", 0);
        run = Mathf.Clamp(run, 0, 4);
        //Invoke("JojomamaloDialogo", 2.5f);
        StartCombat();
    }

    public void JojomamaloDialogo()
    {
        dialogueTrigger.UpdatePath(run);
        dialogueTrigger.BossTriggerDialogue(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_combat)
            return;
        StasisUpdate();
        Actions.JojoActions newAction = (Actions.JojoActions) masterMind.GetAction();
        if (newAction != _actualAction)
        {
            skills.ActivateSkill(newAction);
            _actualAction = newAction;
            Debug.LogWarning(_actualAction);
        }
        if (_active)
        {
            UpdateWeaponAngle();
            _navMeshAgent.speed = stats.GetSpeedValue();
            var pos = _navMeshAgent.gameObject.transform.position;
            var heading = pos - _target.position;
            //Debug.Log(_objetive);
            Vector3 objetive;
            switch (_objetive)
            {
                case Objetives.Near:
                    _navMeshAgent.stoppingDistance = nearDistance;
                    objetive = _target.position;
                    break;
                case Objetives.Mid:
                    _navMeshAgent.stoppingDistance = 0f;
                    objetive = _target.position + (heading / heading.magnitude) * midDistance;
                    break;
                case Objetives.Far:
                    _navMeshAgent.stoppingDistance = 0f;
                    objetive = _target.position + (heading / heading.magnitude) * farDistance;
                    break;
                case Objetives.None:
                    objetive = pos;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //Debug.Log(_target.position.ToString()  + " " +  stasis + " " + objetive.ToString());
            Debug.DrawLine(pos, objetive, new Color(1f, 0f, 0f));
            _navMeshAgent.destination = objetive;
        }
    }

    public void StartCombat()
    {
        _combat = true;
    }
    
    private void FixedUpdate()
    {
        if (!_combat)
            return;
        _elapsedTime += Time.fixedDeltaTime;
        if (_elapsedTime > attackCooldown)
        {
            masterMind.AttackTrigger();
            _elapsedTime = 0f;
        }
    }

    public void UpdateWeaponAngle()
    {
        Vector3 dir = _target.position - jojoarma.gameObject.transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        jojoarma.SetOrientation(angle);
        animationController.UpdateDirection(angle);
    }
    
    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public void Damage(Vector3 enemyPos, float cantidad, Elements.Element element)
    {
        StasisActionUpdate(StasisActions.Damage, cantidad);
        masterMind.DmgTrigger();
        if (!invincible)
        {
            sounds.LaunchSound(JojoSounds.JojoSoundList.Dmg);
            DamageNumber dmgN = Instantiate(prefabDamage, transform.position, Quaternion.identity);
            dmgN.Inicializar(cantidad, transform);
            float multiplier = Elements.GetElementMultiplier(element, stats.element);
            if (multiplier > 1.1f)
                dmgN.number.color = Color.red;
            else if (multiplier < 0.9f)
                dmgN.number.color = Color.cyan;
            else
                dmgN.number.color = Color.yellow; ;

            _damageAcumulated += cantidad;
        }
        
    }

    public void UpdatePosition(int newPos)
    {
        _actualPos = newPos;
        Debug.Log("Teleporting towards: " + _locations[_actualPos].x + " " + _locations[_actualPos].y);
        gameObject.transform.position =
            IsometricUtils.CoordinatesToWorldSpace(_locations[_actualPos].x, _locations[_actualPos].y);
    }
    
    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void DisableMovement(float time)
    {
        _active = false;
        _navMeshAgent.speed = 0f;
        Invoke(nameof(EnableMovement), time);
    }

    private void EnableMovement()
    {
        _navMeshAgent.speed = stats.GetSpeedValue();
        _active = true;
    }

    public override void Attack()
    {
        
    }
}
