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
    private int _hitsCountdown = 2;
    private int _actualPos;
    private float _damageAcumulated = 0;
    private bool _active = true;
    private Transform _target;
    private bool _explosion = false;
    private Vector2[] _locations = new Vector2[NumPositions];
    private NavMeshAgent _navMeshAgent;
    public DamageNumber prefabDamage;
    public JojomamaloAnimationController animationController;

    public bool combat;
    public float attackCooldown;
    private float _elapsedTime = 0;
    private SpriteRenderer _spr;
    [SerializeField] private Weapon jojoarma;
    [SerializeField] private JojomaloSkills skills;

    public Vector3 TargetPos => _target.position;
    public int ActualPos => _actualPos;

    //Dialogos
    private int run = 0;
    public DialogueTrigger dialogueTrigger;

    void Awake()
    {
        combat = false;
        audioSrc = GameObject.Find("GameManager").GetComponent<AudioSource>();
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _navMeshAgent.stoppingDistance = 1f;
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        MapInstance map = SingletoneGameController.MapManager.ActualMap;
        stats = gameObject.GetComponent<CharacterStats>();
        _spr = gameObject.GetComponent<SpriteRenderer>();
        _target = SingletoneGameController.PlayerActions.player.gameObject.transform;
        _locations[0] = new Vector2(map.dims[0]-4, 0);
        _locations[1] = new Vector2(map.dims[1]+4, 0);
        _locations[2] = new Vector2(0, map.dims[2]-2);
        _locations[3] = new Vector2(0, map.dims[3]+2);
        
        UpdatePosition(0);

        BaseWeapon newJojoArma = new RangedWeapon();
        newJojoArma.Randomize(1);
        jojoarma.ChangeWeapon(newJojoArma);
        _navMeshAgent.speed = 0f;
    }

    private void Start()
    {
        audioSrc.Stop();
        audioSrc.clip = Jojomamalo_Fight;
        audioSrc.Play();
        run = PlayerPrefs.GetInt("Jojomamalos", 0);
        run = Mathf.Clamp(run, 0, 4);
        Invoke("JojomamaloDialogo", 2.5f);
        //StartCombat();
    }

    public void JojomamaloDialogo()
    {
        dialogueTrigger.UpdatePath(run);
        dialogueTrigger.BossTriggerDialogue(this);
    }

    public void StartCombat()
    {
        combat = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (_active && combat)
        {
            UpdateWeaponAngle();
            _navMeshAgent.speed = stats.GetSpeedValue();
            _navMeshAgent.destination = _target.position;
            
        }
        
    }

    public void UpdateWeaponAngle()
    {
        Vector3 dir = _target.position - jojoarma.gameObject.transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        jojoarma.SetOrientation(angle);
        animationController.UpdateDirection(angle);
    }

    private void FixedUpdate()
    {
        if (combat)
        {
            _elapsedTime += Time.fixedDeltaTime;
            if (_elapsedTime > attackCooldown)
            {
                switch (Random.Range(0,4))
                {
                    case 0:
                        skills.ActivateSkill(JojomaloSkills.Skills.LineAttack);
                        break;
                    case 1:
                        skills.ActivateSkill(JojomaloSkills.Skills.BowAttack);
                        break;
                    case 2:
                        skills.ActivateSkill(JojomaloSkills.Skills.SnakeAttack);
                        break;
                    case 3:
                        skills.ActivateSkill(JojomaloSkills.Skills.AreaAttack);
                        break;
                }

                _elapsedTime = 0f;
            } 
        }
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public void Damage(Vector3 enemyPos, float cantidad, Elements.Element element)
    {
        DamageNumber dmgN = Instantiate(prefabDamage, transform.position, Quaternion.identity);
        sounds.LaunchSound(JojoSounds.JojoSoundList.Dmg);  
        if (_hitsCountdown > 0)
        { 
            dmgN.Inicializar(0, transform);
            _hitsCountdown--;
            skills.ActivateSkill(JojomaloSkills.Skills.Tp, cantidad.ToString(CultureInfo.InvariantCulture));
        }
        else
        {
            dmgN.Inicializar(cantidad, transform);
            ColorDmg(element);
            _damageAcumulated += cantidad;
            if (_damageAcumulated >= 10 && !_explosion)
            {
                skills.ActivateSkill(JojomaloSkills.Skills.ExplosionCounter, _damageAcumulated.ToString());
                skills.ActivateSkill(JojomaloSkills.Skills.ChangueElement, "" + (int) Elements.GetCounter(SingletoneGameController.PlayerActions.player.Stats.element));
                _explosion = true;
            }
            if (_damageAcumulated >= 20)
            {
                skills.ActivateSkill(JojomaloSkills.Skills.Tp);
                _damageAcumulated = 0;
                _explosion = false;
            }
                
        }
    }

    public void UpdatePosition(int newPos)
    {
        _actualPos = newPos;
        Debug.Log("Teleporting towards: " + _locations[_actualPos].x + " " + _locations[_actualPos].y);
        gameObject.transform.position =
            IsometricUtils.CoordinatesToWorldSpace(_locations[_actualPos].x, _locations[_actualPos].y);
    }

    

    private void ColorDmg(Elements.Element elementDmg)
    {
        /*
        float multiplier = Elements.GetElementMultiplier(elementDmg, stats.element);
        if(multiplier>1.1f)
            _spr.color = Color.red;
        else if(multiplier<0.9f)
            _spr.color = Color.cyan;
        else 
            _spr.color = Color.yellow;
        Invoke(nameof(RevertColor), 0.2f);*/
    }
    
    
    
    public void RevertColor()
    {
        _spr.color = Color.white;
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

    public int GetDifficulty()
    {
        return 1;
    }
}
