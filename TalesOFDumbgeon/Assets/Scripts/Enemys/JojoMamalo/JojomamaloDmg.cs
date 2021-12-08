using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JojomamaloDmg : Mind
{
    [NonSerialized] public JojoMamaloMind Mind;
    
    public Weapon weapon;
    public float timerActions;
    public float closePlayerDistance;
    
    private float _elapsedTime;
    private int _invincibleTpCount;
    private Transform _player;
    private void Start()
    {
        _player = SingletoneGameController.PlayerActions.player.gameObject.transform;
        _invincibleTpCount = 2;
        _elapsedTime = 0f;
    }

    private void FixedUpdate()
    {
        _elapsedTime += Time.fixedDeltaTime;
    }

    public override int GetAction()
    {
        if (_invincibleTpCount > 0)
        {
            _invincibleTpCount--;
            return (int) Actions.JojoActions.TeleportHealh;
        }
        if (body.stats.GetActualHealth() < Mind.health_stages[Mind.stage])
        {
            Mind.stage++;
            return (int) Actions.JojoActions.Explosion;
        }

        if (_elapsedTime >= timerActions)
        {
            _elapsedTime = 0;
            if (Mind.stage >= 1)
            {
                if (Vector3.Distance(_player.position, body.gameObject.transform.position) <= closePlayerDistance)
                {
                    return (int) Actions.JojoActions.ExplosionAcumulada;
                }

                if (Elements.GetElementMultiplier(weapon.weaponInfo.Stats.element,
                    SingletoneGameController.PlayerActions.player.Stats.element) < 1.9999f)
                {
                    return (int) Actions.JojoActions.ElementChange;
                }

                return (int) Actions.JojoActions.AreaAttackAndTeleport;
            }

            return (int) Actions.JojoActions.Teleport;
        }

        return (int) Actions.JojoActions.RecibirDmg;
    }
}
