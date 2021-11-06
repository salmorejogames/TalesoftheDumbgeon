using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class JojoMamaloBehaviour : MonoBehaviour, IDeadable
{
    private const int NumPositions = 4;
    private int _hitsCountdown = 2;
    private int _actualPos;
    private float _damageAcumulated = 0;
    
    private Vector2[] _locations = new Vector2[NumPositions];

    private CharacterStats _stats;
    private MapInstance _map;
    private SpriteRenderer _spr;
    void Start()
    {
        _map = SingletoneGameController.MapManager.ActualMap;
        _stats = gameObject.GetComponent<CharacterStats>();
        _spr = gameObject.GetComponent<SpriteRenderer>();
        
        _locations[0] = new Vector2(_map.dims[0]-4, 0);
        _locations[1] = new Vector2(_map.dims[1]+4, 0);
        _locations[2] = new Vector2(0, _map.dims[2]-2);
        _locations[3] = new Vector2(0, _map.dims[3]+2);
        
        UpdatePosition(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public void Damage(GameObject enemy, float cantidad, Elements.Element element)
    {
        if (_hitsCountdown > 0)
        {
            _hitsCountdown--;
            TeleportInvulnerable(true);
        }
        else
        {
            ColorDmg(element);
            _damageAcumulated += cantidad;
            if (_damageAcumulated >= 20)
            {
                TeleportInvulnerable(false);
                _damageAcumulated = 0;
            }
                
        }
    }

    private void UpdatePosition(int newPos)
    {
        _actualPos = newPos;
        Debug.Log("Teleporting towards: " + _locations[_actualPos].x + " " + _locations[_actualPos].y);
        gameObject.transform.position =
            IsometricUtils.CoordinatesToWorldSpace(_locations[_actualPos].x, _locations[_actualPos].y);
    }

    private void TeleportInvulnerable(bool heal)
    {
        
        int ran;
        do
        {
            ran = Random.Range(0, NumPositions);
        } while (ran == _actualPos);
        UpdatePosition(ran);
        if(heal)
            _stats.Heal(_stats.maxHealth);
       
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
    
}
