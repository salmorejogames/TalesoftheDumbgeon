using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JojoMamaloMind : Mind
{
    private bool canAttack;
    private bool damageReceived;
    private bool doingAction;

    [SerializeField] private float minStasis;
    [SerializeField] private float maxStasis;
    [SerializeField] private Mind attackMind;
    [SerializeField] private Mind dmgMind;

    

    public Actions.JojoActions actual;

    public void Start()
    {
        actual = Actions.JojoActions.Presentacion;
        doingAction = true;
        canAttack = false;
        damageReceived = false;
    }

    public void AttackTrigger()
    {
        canAttack = true;
    }

    public void DmgTrigger()
    {
        damageReceived = true;
    }

    public void EndAction()
    {
        doingAction = false;
    }

    public override int GetAction()
    {
        switch (actual)
        {
            case Actions.JojoActions.Presentacion:
                if (doingAction)
                    return (int)Actions.JojoActions.Presentacion;
                else
                {
                    return UpdateMovement();
                }
            case Actions.JojoActions.MantenerDistancia:
            case Actions.JojoActions.Acercarse:
            case Actions.JojoActions.Alejarse:
                if (damageReceived)
                {
                    actual = Actions.JojoActions.RecibirDmg;
                    return GetAction();
                }
                if (canAttack)
                {
                    actual = Actions.JojoActions.Atacar;
                    return GetAction();
                }
                return (int) actual;
            case Actions.JojoActions.Atacar:
                if (!canAttack && !doingAction)
                    return UpdateMovement();
                if (doingAction)
                    return (int)actual;
                doingAction = true;
                canAttack = false;
                return attackMind.GetAction();
            case Actions.JojoActions.RecibirDmg:
                if (!damageReceived && !doingAction)
                    return UpdateMovement();
                if (doingAction)
                    return (int)actual;
                doingAction = true;
                damageReceived = false;
                return dmgMind.GetAction();
        }
        throw new System.NotImplementedException();
    }

    private int UpdateMovement()
    {
        if (body.stasis < minStasis)
        {
            actual = Actions.JojoActions.Alejarse;
            return (int)Actions.JojoActions.Alejarse;
        }
        if (body.stasis > minStasis)
        {
            actual = Actions.JojoActions.Acercarse;
            return (int)Actions.JojoActions.Acercarse;
        }
        actual = Actions.JojoActions.MantenerDistancia;
        return (int)Actions.JojoActions.MantenerDistancia;
    }

}
