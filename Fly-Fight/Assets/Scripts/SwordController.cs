using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField] private DynamicJoystick joy;
    [SerializeField] private Rigidbody _swordRB;
    [SerializeField] private float _speed = 2f;

    private void FixedUpdate()
    {
        _swordRB.velocity = new Vector3(joy.Horizontal * _speed, _swordRB.velocity.y, joy.Vertical * _speed);

        if (joy.Horizontal != 0 || joy.Vertical != 0)
        {
            //transform.rotation = Quaternion.LookRotation(_swordRB.velocity);
            
            //transform.rotation =  Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_swordRB.velocity), Time.deltaTime);
            //transform.rotation = Quaternion.Euler(-90f, Quaternion.LookRotation(_swordRB.velocity).y, -180f);
        }


    }
}
