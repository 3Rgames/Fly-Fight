using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField] private DynamicJoystick joy;
    [SerializeField] private PlayerController _playerController;
    [Header("Move Params")]
    [Space]
    [SerializeField] private Rigidbody _swordRB;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotationSpeed = 10f;
    [Space]
    [Header("Balance")]
    [Space]
    [SerializeField] private FlyBalancer _flyBalancer;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundOffcet = 1f;
    private Vector3 _forceDirection;

    private float x = -90f, z = -180f;

    private void OnEnable()
    {
        joy.OnPointU += NonActive;
        joy.OnPointD += Active;
    }

    private void Start()
    {
        IEnumerator NumbCor()
        {
            while (true)
            {
                x = Random.Range(-80f,-100f);
                z = Random.Range(-170f, -190f);
                yield return new WaitForSeconds(1f);
            }
        }
        StartCoroutine(NumbCor());
    }

    private void FixedUpdate()
    {
        if (joy.Horizontal != 0 || joy.Vertical != 0)
        {
            _swordRB.velocity = Vector3.zero;
            _forceDirection = new Vector3(joy.Horizontal, 0.0f, joy.Vertical);

            if (TryGetGroundPosition(out var groundPosition))
                _swordRB.AddForce(Vector3.up *30f* (groundPosition + _groundOffcet - transform.position.y) * _speed * Time.deltaTime,
                    ForceMode.Force);

            _swordRB.AddForce(_forceDirection * 100f * _speed * Time.deltaTime, ForceMode.Force);
            _flyBalancer.Balance(_forceDirection, _swordRB.position);

            _swordRB.MoveRotation(Quaternion.Lerp(
                transform.rotation, Quaternion.Euler(x, Quaternion.LookRotation(_swordRB.velocity).eulerAngles.y, z),
                Time.deltaTime / _rotationSpeed));
        }
    }

    private bool TryGetGroundPosition(out float groundPositon)
    {
        
        Ray landingRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(landingRay, out var hit, _groundLayer))
        {
            groundPositon = hit.point.y;
            return true;
        }
        groundPositon = 0;
        return false;
    }

    private void Active()
    {
        UIController.Instance.StopTutorial();
        _playerController.Active();
    }

    private void NonActive()
    {
        _swordRB.velocity = Vector3.zero;
        _swordRB.angularVelocity = Vector3.zero;
        _playerController.NonActive();
    }

    private void OnDisable()
    {
        joy.OnPointU += NonActive;
        joy.OnPointD += Active;
    }
}
