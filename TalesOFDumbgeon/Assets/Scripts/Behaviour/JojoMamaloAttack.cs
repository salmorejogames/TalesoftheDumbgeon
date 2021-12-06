using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JojoMamaloAttack : Mind
{

    [SerializeField] private float minDistancePlayer;
    [SerializeField] private float maxDistancePlayer;

    private const int STAGES = 3;
    private Transform _player;
    private float[] health_stages;
    public int stage;

    private float playerDistanceValue;
    private float lifeUntilPhaseValue;
    private float extasisValue;
    private float stage2;
    private float stage3;

    private void Start()
    {
       _player = SingletoneGameController.PlayerActions.player.gameObject.transform;
        health_stages = new float[STAGES];
        float quarter_life =  body.stats.maxHealth/(STAGES+1);
        for(int i = 0; i < STAGES; i++)
        {
            health_stages[i] = quarter_life * (STAGES - i);
        }
        stage = 0;
    }
    public override int GetAction()
    {
        updateValues();
        return 1;
    }

    private void updateValues()
    {
        float distance = Vector3.Distance(_player.position, body.gameObject.transform.position);
        if (distance <= minDistancePlayer)
            playerDistanceValue = 0;
        else if (distance >= maxDistancePlayer)
            playerDistanceValue = 1;
        else
        {
            float distanceSegment = maxDistancePlayer - minDistancePlayer;
            float percentSegment = distance - minDistancePlayer;
            playerDistanceValue = distanceSegment / percentSegment;
        }
        

    }

}
