using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal;

public class BaseEnemy : MonoBehaviour
{
    public AudioSource Audio;
    [NonSerialized] public float stasis = 0;
    public int difficulty = 1;
    public CharacterStats stats;
    [SerializeField] protected float stasisFactor = 0.025f;

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
                Debug.Log("Antes: " +stasis);
                stasis += amount;
                Debug.Log("Despues: " + stasis);
                break;
            case StasisActions.Impact:
                Debug.Log("Antes: " +stasis);
                if(amount>0.0001 ||amount<-0.0001){}
                    stasis += (amount*4/ stats.maxHealth);
                Debug.Log("Despues: " + stasis);
                break;
            case StasisActions.Damage:
                Debug.Log("Antes: " +stasis);
                if (amount > 0.0001 || amount < -0.0001)
                    stasis -= (amount*4/stats.maxHealth);
                Debug.Log("Despues: " + stasis);
                break;
        }

    }
}
