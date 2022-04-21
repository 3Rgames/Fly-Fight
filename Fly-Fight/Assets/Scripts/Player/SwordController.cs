using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField] private DynamicJoystick joy;
    [SerializeField] private Rigidbody _swordRB;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private List<Rigidbody> _bodyParts = new List<Rigidbody>();
    private Vector3 _forceDirection;
    private Vector3 _maxVelocity, _minVelocity;

    private float x = -90f, z = -180f;

    private void OnEnable()
    {
        joy.OnPointU += NonActive;
        joy.OnPointD += Active;
    }

    private void Start()
    {
        _maxVelocity = Vector3.one * 3f;
        _minVelocity = Vector3.one * -3f;
        IEnumerator NumbCor()
        {
            while (true)
            {
                x = Random.Range(-70f, -110f);
                z = Random.Range(-170f, -200f);
                yield return new WaitForSeconds(1f);
            }
        }
        StartCoroutine(NumbCor());
    }

    private void FixedUpdate()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, 1f, 1.8f), transform.localPosition.z);
        _swordRB.angularVelocity = Clamp(_swordRB.angularVelocity, _minVelocity, _maxVelocity);

        if (joy.Horizontal != 0 || joy.Vertical != 0)
        {
            _swordRB.velocity = Vector3.zero;
            _forceDirection = new Vector3(joy.Horizontal, _swordRB.velocity.y, joy.Vertical);
            _swordRB.AddForce(_forceDirection * 100f * _speed * Time.deltaTime, ForceMode.Force);

            BodyFly();

            _swordRB.MoveRotation(Quaternion.Lerp(
                transform.rotation, Quaternion.Euler(x, Quaternion.LookRotation(_swordRB.velocity).eulerAngles.y, z),
                Time.deltaTime / _rotationSpeed));
        }
    }

    private void BodyFly()
    {
        for(int i=0;i< _bodyParts.Count;i++)
        {
            _bodyParts[i].velocity = Vector3.zero;
            _bodyParts[i].AddForce(Vector3.up * Vector3.Distance(transform.position, _bodyParts[i].position), ForceMode.Force);
        }
    }

    private Vector3 Clamp(Vector3 value, Vector3 Min, Vector3 Max)
    {
        value.x = Mathf.Clamp(value.x, Min.x, Max.x);
        value.y = Mathf.Clamp(value.y, Min.y, Max.y);
        value.z = Mathf.Clamp(value.z, Min.z, Max.z);
        return value;
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
