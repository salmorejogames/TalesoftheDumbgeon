using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mind : MonoBehaviour
{
    [SerializeField] protected BaseEnemy body;
    public abstract int GetAction();

}
