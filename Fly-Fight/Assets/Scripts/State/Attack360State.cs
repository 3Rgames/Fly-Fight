using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack360State : State
{
    private HashAnimationNames _animBase = new HashAnimationNames();
    private Animator _animator;

    public Attack360State(Animator animator)
    {
        _animator = animator;
    }

    public override void Enter()
    {
        base.Enter();
        _animator.StopPlayback();
        _animator.CrossFade(_animBase.Attack360Hash, 0.05f);
    }

    public override void Exit()
    {
        base.Exit();
        _animator.StopPlayback();
    }
}
