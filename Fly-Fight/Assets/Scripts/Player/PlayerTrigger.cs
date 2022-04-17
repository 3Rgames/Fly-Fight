using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Transform _target;
    private float _health = 100f;

    private void FixedUpdate()
    {
        transform.localPosition = new Vector3(_target.localPosition.x - 0.8f, 1f, _target.localPosition.z + 0.03f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.HIT)
        {
            _health -= 10f;
            _healthBar.HealthBarUpdate(_health);
        }
    }
}
