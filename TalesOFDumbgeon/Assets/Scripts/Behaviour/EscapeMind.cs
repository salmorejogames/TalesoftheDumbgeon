using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMind : Mind
{
    private Generator _home;
    [SerializeField] private float closeDistance = 1f;
    [SerializeField] private float inBaseDistance = 0.25f;
    private Transform _player;
    void Start()
    {
        _home = gameObject.GetComponent<EnemyIdle>().GetHome();
        _player = SingletoneGameController.PlayerActions.player.transform;
    }
    
    public override int GetAction()
    {
        Vector3 pos = body.transform.position;
        if (Vector2.Distance(pos, _home.gameObject.transform.position) < inBaseDistance &&
            Vector2.Distance(pos, _player.position) < closeDistance)
            return (int) EnemyMindController.EnemyBaseActions.RunFromPlayer;
        if (Vector2.Distance(pos, _home.gameObject.transform.position)>inBaseDistance)
            return (int) EnemyMindController.EnemyBaseActions.GoBackHome;
        return (int) EnemyMindController.EnemyBaseActions.Descanso;
    }
}