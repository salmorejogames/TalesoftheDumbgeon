using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int ReleaseAttack = Animator.StringToHash("ReleaseAttack");
    private static readonly int EndAttack1 = Animator.StringToHash("EndAttack");
    [SerializeField] private SpriteRenderer colorRenderer;
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

    public void ChangeColor(Elements.Element element)
    {
        if (element == Elements.Element.Normal)
            colorRenderer.color = Color.white;
        else
            colorRenderer.color = SingletoneGameController.InfoHolder.LoadColor(element);
    }
}
