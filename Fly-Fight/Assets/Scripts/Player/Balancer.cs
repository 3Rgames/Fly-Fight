using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balancer : MonoBehaviour
{
    [SerializeField] private Rigidbody _balancerRB;
    [SerializeField] private Rigidbody _hipsRB;
    [SerializeField] private Vector3 _balancerOffcet;
    [SerializeField] private SpringJoint _balancerJoint;
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
        _balancerRB.MovePosition(_hipsRB.position + transform.TransformVector(_balancerOffcet));
    }
}
