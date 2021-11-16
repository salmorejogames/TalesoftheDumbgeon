using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCard : MonoBehaviour
{
    public ItemCard card;
    private Animator _animator;
    private static readonly int Launch = Animator.StringToHash("Launch");
    [SerializeField] private float _time;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimaton()
    {
        _animator.SetTrigger(Launch);
        StartCoroutine(DeleteCard());
    }

    private IEnumerator DeleteCard()
    {
        yield return new WaitForSeconds(_time);
        Destroy(gameObject);
    }
}
