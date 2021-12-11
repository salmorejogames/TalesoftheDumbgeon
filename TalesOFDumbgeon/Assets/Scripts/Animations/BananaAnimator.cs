using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int ReleaseAttack = Animator.StringToHash("ReleaseAttack");
    private static readonly int EndAttack1 = Animator.StringToHash("EndAttack");

    public void PrepareAttack()
    {
        animator.SetTrigger(Attack);
    }

    public void StartAttack()
    {
        animator.SetTrigger(ReleaseAttack);
    }

    public void EndAttack()
    {
        animator.SetTrigger(EndAttack1);
    }
}
