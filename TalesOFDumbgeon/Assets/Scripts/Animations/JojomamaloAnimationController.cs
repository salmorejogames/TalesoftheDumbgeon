using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JojomamaloAnimationController : MonoBehaviour
{
    public Animator northEast;
    public Animator northWest;
    public Animator southEast;
    public Animator southWest;

    public Animator current;
    public JojoDirection direction;

    private AnimationAction _animationAction = AnimationAction.Idle;
    private enum AnimationAction
    {
        Idle,
        Attack,
        Charge,
        ChargeAttack
    }
    public enum JojoDirection
    {
        Ne,
        Nw,
        Se,
        Sw
    }
    void Start()
    {
        current.gameObject.SetActive(true);
    }

    public void SetCharge()
    {
        current.SetTrigger("Charge");
        _animationAction = AnimationAction.Charge;
    }

    public void SetAttack()
    {
        current.SetTrigger("Attack");
        if (_animationAction.Equals(AnimationAction.Charge))
            _animationAction = AnimationAction.ChargeAttack;
        else
            _animationAction = AnimationAction.Attack;
    }
    
    public void SetStop()
    {
        if (!_animationAction.Equals(AnimationAction.Idle))
            current.SetTrigger("Stop");
        
        _animationAction = AnimationAction.Idle;
  
    }

    public void UpdateDirection(float angle)
    {
        angle = angle % 360;
        if (angle < 0)
            angle += 360;
        if (angle < 90)
        {
            if (direction == JojoDirection.Ne) return;
            direction = JojoDirection.Ne;
            current.gameObject.SetActive(false);
            current = northEast;
            current.gameObject.SetActive(true);
        }else if (angle < 180)
        {
            if (direction == JojoDirection.Nw) return;
            direction = JojoDirection.Nw;
            current.gameObject.SetActive(false);
            current = northWest;
            current.gameObject.SetActive(true);
        }else if (angle < 270)
        {
            if (direction == JojoDirection.Sw) return;
            direction = JojoDirection.Sw;
            current.gameObject.SetActive(false);
            current = southWest;
            current.gameObject.SetActive(true);
        }
        else
        {
            if (direction == JojoDirection.Se) return;
            direction = JojoDirection.Se;
            current.gameObject.SetActive(false);
            current = southEast;
            current.gameObject.SetActive(true);
        }

        switch (_animationAction)
        {
            case AnimationAction.Idle:
                break;
            case AnimationAction.Attack:
                current.SetTrigger("Attack");
                break;
            case AnimationAction.Charge:
                current.SetTrigger("Charge");
                break;
            case AnimationAction.ChargeAttack:
                current.SetTrigger("Charge");
                current.SetTrigger("Attack");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
