using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Interfaces;
using UnityEngine;

public class JojoMamaloBehaviour : MonoBehaviour, IDeadable, IMovil
{
    public const int NumPositions = 4;
    private int _hitsCountdown = 2;
    private int _actualPos;
    private float _damageAcumulated = 0;
    private bool _active = true;
    private Transform _target;
    private bool _explosion = false;
    private Vector2[] _locations = new Vector2[NumPositions];

    private CharacterStats _stats;
    private SpriteRenderer _spr;
    [SerializeField] private Weapon jojoarma;
    [SerializeField] private JojomaloSkills skills;

    public int ActualPos => _actualPos;
    public CharacterStats Stats => _stats;

    void Start()
    {
        MapInstance map = SingletoneGameController.MapManager.ActualMap;
        _stats = gameObject.GetComponent<CharacterStats>();
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
    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            Vector3 dir = _target.position - jojoarma.gameObject.transform.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            jojoarma.SetOrientation(angle);
        }
        
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public void Damage(Vector3 enemyPos, float cantidad, Elements.Element element)
    {
        if (_hitsCountdown > 0)
        {
            _hitsCountdown--;
            skills.ActivateSkill(JojomaloSkills.Skills.Tp, cantidad.ToString(CultureInfo.InvariantCulture));
        }
        else
        {
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
        skills.ActivateSkill(JojomaloSkills.Skills.BowAttack);
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
        float multiplier = Elements.GetElementMultiplier(elementDmg, _stats.element);
        if(multiplier>1.1f)
            _spr.color = Color.red;
        else if(multiplier<0.9f)
            _spr.color = Color.cyan;
        else 
            _spr.color = Color.yellow;
        Invoke(nameof(RevertColor), 0.2f);
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
        Invoke(nameof(EnableMovement), time);
    }

    public void DisableMovement()
    {
        _active = false;
    }

    private void EnableMovement()
    {
        _active = true;
    }

    public void AbleMovement()
    {
        _active = true;
    }

}
