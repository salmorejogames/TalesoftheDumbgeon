using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JojoMamaloMind : Mind
{
    public const int Stages = 3;
    
    
    private bool _canAttack;
    private bool _damageReceived;
    private bool _doingAction;

    [SerializeField] private float minStasis;
    [SerializeField] private float maxStasis;
    [SerializeField] private JojoMamaloAttack attackMind;
    [SerializeField] private JojomamaloDmg dmgMind;
    
    public float MINStasis => minStasis;
    public float MAXStasis => maxStasis;

    [NonSerialized] public Actions.JojoActions Actual;
    [NonSerialized] public int Stage;
    [NonSerialized] public float[] HealthStages;
    
    public void Start()
    {
        Actual = Actions.JojoActions.Presentacion;
        attackMind.Mind = this;
        dmgMind.Mind = this;
        _doingAction = true;
        Stage = 0;
        _canAttack = false;
        _damageReceived = false;
        
        HealthStages = new float[Stages];
        float quarterLife =  body.stats.maxHealth/(Stages+1);
        for(int i = 0; i < Stages; i++)
        {
            HealthStages[i] = quarterLife * (Stages - i);
        }
    }

    public void AttackTrigger()
    {
        _canAttack = true;
    }

    public void DmgTrigger()
    {
        _damageReceived = true;
    }

    public void EndAction()
    {
        _doingAction = false;
        UpdateMovement();
    }

    public override int GetAction()
    {
        switch (Actual)
        {
            case Actions.JojoActions.Presentacion:
                if (_doingAction)
                    return (int)Actions.JojoActions.Presentacion;
                else
                {
                    return UpdateMovement();
                }
            case Actions.JojoActions.MantenerDistancia:
            case Actions.JojoActions.Acercarse:
            case Actions.JojoActions.Alejarse:
                if (_damageReceived)
                {
                    Actual = Actions.JojoActions.RecibirDmg;
                    return GetAction();
                }
                if (_canAttack)
                {
                    Actual = Actions.JojoActions.Atacar;
                    return GetAction();
                }
                return (int) Actual;
            case Actions.JojoActions.Atacar:
                if (!_canAttack && !_doingAction)
                    return UpdateMovement();
                if (_doingAction)
                    return (int)Actual;
                _doingAction = true;
                _canAttack = false;
                return attackMind.GetAction();
            case Actions.JojoActions.RecibirDmg:
                if (!_damageReceived && !_doingAction)
                    return UpdateMovement();
                if (_doingAction)
                    return (int)Actual;
                _doingAction = true;
                _damageReceived = false;
                return dmgMind.GetAction();
        }
        throw new System.NotImplementedException();
    }

    private int UpdateMovement()
    {
        if (body.stasis < minStasis)
        {
            Actual = Actions.JojoActions.Alejarse;
            return (int)Actions.JojoActions.Alejarse;
        }
        if (body.stasis > minStasis)
        {
            Actual = Actions.JojoActions.Acercarse;
            return (int)Actions.JojoActions.Acercarse;
        }
        Actual = Actions.JojoActions.MantenerDistancia;
        return (int)Actions.JojoActions.MantenerDistancia;
    }

}
