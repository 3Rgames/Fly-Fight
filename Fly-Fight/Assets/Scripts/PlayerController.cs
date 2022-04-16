using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CopyLimb _playerCopyLimb;
    [SerializeField] private GameObject _rightArm;
    [SerializeField] private GameObject _rightForceArm;
    [SerializeField] private Rigidbody _rightHand;
    [SerializeField] private Rigidbody _spine1;
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

    private void Active()//sword
    {
        _playerCopyLimb.IsPlayerActive = true;
        _playerAnimator.enabled = false;
        _playerAnimator.enabled = true;

        _realSword.enabled = true;
        _fakeSword.SetActive(false);

        _SM.ChangeState(_noneState);
        _rightArm.GetComponent<ConfigurableJoint>().connectedBody = _rightForceArm.GetComponent<Rigidbody>();
        _rightForceArm.GetComponent<ConfigurableJoint>().connectedBody = _rightHand;
    }

    private void NonActive()//animator
    {
        _rightArm.GetComponent<ConfigurableJoint>().connectedBody = _spine1;
        _rightForceArm.GetComponent<ConfigurableJoint>().connectedBody = _rightArm.GetComponent<Rigidbody>();
        _SM.ChangeState(_standUpState);

        _playerCopyLimb.IsPlayerActive = false;

        _realSword.enabled = false;
        _fakeSword.SetActive(true);
    }

}
