using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CopyLimb _playerCopyLimb;
    [SerializeField] private GameObject _fakeSword;
    [SerializeField] private MeshRenderer _realSword;

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

    public void Active()//sword
    {
        _playerCopyLimb.IsPlayerActive = true;

        _realSword.enabled = true;
        _fakeSword.SetActive(false);

        _SM.ChangeState(_noneState);
    }

    public void NonActive()//animator
    {
        _SM.ChangeState(_standUpState);

        _playerCopyLimb.IsPlayerActive = false;

        _realSword.enabled = false;
        _fakeSword.SetActive(true);
    }

}
