using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDownwardState : State
{
    private HashAnimationNames _animBase = new HashAnimationNames();
    private Animator _animator;

    public AttackDownwardState(Animator animator)
    {
        _animator = animator;
    }

    public override void Enter()
    {
        base.Enter();
        _animator.StopPlayback();
        _animator.CrossFade(_animBase.AttackDownwardHash, 0.05f);
    }

    public override void Exit()
    {
        base.Exit();
        _animator.StopPlayback();
    }
}
