using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerebroAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int Atack = Animator.StringToHash("Attack");
    [SerializeField] private SpriteRenderer colorRenderer;
    
    public void StartAttack()
    {
        animator.SetBool(Atack, true);
    }

    public void EndAttack()
    {
        animator.SetBool(Atack, false);
    }

    public void ChangeColor(Elements.Element element)
    {
        if (element == Elements.Element.Normal)
            colorRenderer.color = Color.white;
        else
            colorRenderer.color = SingletoneGameController.InfoHolder.LoadColor(element);
    }
    
}
