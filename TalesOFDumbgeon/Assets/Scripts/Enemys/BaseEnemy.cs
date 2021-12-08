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
    protected float stasisFactor = 0.025f;

    public enum StasisActions {
        Attack,
        Impact,
        Damage
    }

    protected void StasisUpdate()
    {
        stasis = Mathf.Clamp(stasis, -1, 1);
        if (stasis < 0)
            stasis += stasisFactor * Time.deltaTime;
        if(stasis > 0)
            stasis -= stasisFactor * Time.deltaTime;
    }

    //Values between -1 and 1
    public void StasisActionUpdate(StasisActions action, float amount)
    {
        switch (action)
        {
            case StasisActions.Attack:
                stasis += amount;
                break;
            case StasisActions.Impact:
                if(amount>0.0001 ||amount<-0.0001)
                    stasis += (amount/ stats.maxHealth);
                break;
            case StasisActions.Damage:
                if (amount > 0.0001 || amount < -0.0001)
                    stasis -= (amount/stats.maxHealth);
                break;
        }

    }
}