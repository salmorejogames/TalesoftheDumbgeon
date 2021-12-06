using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal;

public class BaseEnemy : MonoBehaviour
{
    public AudioSource audio;
    public float stasis = 0;
    public int difficulty = 1;
    public CharacterStats stats;
    protected float stasisFactor = 0.1f;

    public enum StasisActions {
        Attack,
        Impact,
        Damage
    }

    protected void StasisUpdate()
    {
        Mathf.Clamp01(stasis);
        if (stasis < 0)
            stasis += stasisFactor * Time.deltaTime;
        if(stasis > 0)
            stasis += stasisFactor * Time.deltaTime;
    }

    protected void StasisActionUpdate(StasisActions action, float amount)
    {
        switch (action)
        {
            case StasisActions.Attack:
                stasis += amount;
                break;
            case StasisActions.Impact:
                stasis += (stats.maxHealth / amount);
                break;
            case StasisActions.Damage:
                stasis -= (stats.maxHealth / amount);
                break;
        }

    }
}