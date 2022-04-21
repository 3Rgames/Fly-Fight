using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerTrigger _playerTrigger;
    [SerializeField] private CopyLimb _copyLimb;
    [SerializeField] private ParticleSystem _death;
    [SerializeField] private Balancer _balancer;
    [SerializeField] private Animator _playerAnimator;

    private StateMachine _SM;
    private NoneState _noneState;
    private StandUpState _standUpState;

    private void Start()
    {
        _SM = new StateMachine();
        _noneState = new NoneState(_playerAnimator);
        _standUpState = new StandUpState(_playerAnimator);

        _SM.Initialize(_noneState);
    }

    private void OnEnable()
    {
        _playerTrigger.OnDeath += Death;
    }

    public void Active()//sword
    {
        _balancer.UseBalance = false;
        _copyLimb.IsPlayerActive = true;
        _copyLimb.ActiveRagdoll(true);
        _SM.ChangeState(_noneState);
    }

    public void NonActive()//animator
    {
        _balancer.UseBalance = true;
        _SM.ChangeState(_standUpState);
        _copyLimb.ActiveRagdoll(false);
        _copyLimb.IsPlayerActive = false;
    }

    private void Death()
    {
        _copyLimb.IsPlayerActive = true;

        _playerTrigger.HealthBarInActive();
        _copyLimb.DeleteJoints();
        TapTicController.Instance.Failure();
        _death.Play();
        UIController.Instance.LevelEnd(false);
    }

    private void OnDisable()
    {
        _playerTrigger.OnDeath -= Death;
    }

}
