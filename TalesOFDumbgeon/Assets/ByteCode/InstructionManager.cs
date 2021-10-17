using System;
using System.Collections;
using System.Collections.Generic;
using ByteCode;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    public static InstructionManager instance;
    public static VM Vm;
    private void Awake()
    {
        if (instance == null)
        {
            Vm = new VM();
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this);
        }
    }

    public void SetHealth(int amount, int target, bool relative)
    {
        Debug.Log( "amount: "  + amount + " target: " + target + " relative: " + relative);
    }

    public void SetSpeed(float pos, float neg)
    {
        Debug.Log("positive: " + pos + " negative: " + neg);
    }
    
    
}
