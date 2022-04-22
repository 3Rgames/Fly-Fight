using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balancer : MonoBehaviour
{
    [Header("Components")]
    [Space]
    [SerializeField] private Rigidbody _balancerRB;
    [SerializeField] private Rigidbody _hipsRB;
    [SerializeField] private SpringJoint _balancerJoint;
    [Space]
    [Header("Balance Params")]
    [Space]
    [SerializeField] private float _balancerOffcet;
    [SerializeField] private float _balanceForce;
    private bool _useBalance;

    public bool UseBalance
    {
        get => _useBalance;
        set
        {
            _useBalance = value;
            _balancerJoint.spring = value ? _balanceForce : 0;
            _balancerRB.isKinematic = value;
        }
    }

    private void FixedUpdate()
    {
        _balancerRB.MovePosition(_hipsRB.position + Vector3.up * _balancerOffcet);
    }
}
