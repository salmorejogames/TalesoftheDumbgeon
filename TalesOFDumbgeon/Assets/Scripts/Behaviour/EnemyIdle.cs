using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : Mind
{
    private Generator _home;
    private int _index;
    
    private void Awake()
    {
        _home = GetComponentInParent<Generator>();
        _index = _home.GetNumber();
    }

    public override int GetAction()
    {
        if (_home.IsCentinel(_index))
            return (int) EnemyMindController.EnemyBaseActions.Wandering;
        if(_home.GetNumEnemys()>2)
            return (int) EnemyMindController.EnemyBaseActions.Talking;
        return (int) EnemyMindController.EnemyBaseActions.Sleeping;
    }

    public Generator GetHome()
    {
        return _home;
    }

    public int GetIndex()
    {
        return _index;
    }
       
    
}
