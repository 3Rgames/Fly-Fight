using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField] private DynamicJoystick joy;
    [SerializeField] private Rigidbody _swordRB;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private PlayerController _playerController;

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
                x = Random.Range(-70f, -110f);
                z = Random.Range(-170f, -200f);
                yield return new WaitForSeconds(1f);
            }
        }
        StartCoroutine(NumbCor());
    }

    private void FixedUpdate()
    {
        _swordRB.velocity = new Vector3(joy.Horizontal * _speed, _swordRB.velocity.y, joy.Vertical * _speed);

        if (joy.Horizontal != 0 || joy.Vertical != 0)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation, Quaternion.Euler(x, Quaternion.LookRotation(_swordRB.velocity).eulerAngles.y, z),
                Time.deltaTime * 5f);
        }
    }

    private void Active()
    {
        UIController.Instance.StopTutorial();
        _playerController.Active();
    }

    private void NonActive()
    {
        _playerController.NonActive();
    }

    private void OnDisable()
    {
        joy.OnPointU += NonActive;
        joy.OnPointD += Active;
    }
}
