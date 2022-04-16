using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBackhandState : State
{
    private HashAnimationNames _animBase = new HashAnimationNames();
    private Animator _animator;

    public AttackBackhandState(Animator animator)
    {
        _animator = animator;
    }

    public override void Enter()
    {
        base.Enter();
        _animator.StopPlayback();
        _animator.CrossFade(_animBase.AttackBackhandHash, 0.05f);
    }

    public override void Exit()
    {
        base.Exit();
        _animator.StopPlayback();
    }
}
