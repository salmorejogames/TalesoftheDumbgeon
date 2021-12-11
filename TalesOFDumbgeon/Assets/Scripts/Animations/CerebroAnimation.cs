using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerebroAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int Atack = Animator.StringToHash("Attack");

    public void StartAttack()
    {
        animator.SetBool(Atack, true);
    }

    public void EndAttack()
    {
        animator.SetBool(Atack, false);
    }
    
}
