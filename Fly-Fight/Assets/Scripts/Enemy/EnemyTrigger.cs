using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Transform _target;
    private float _health = 100f;

    private void FixedUpdate()
    {
        transform.localPosition = _target.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.SWORD)
        {
            _health -= 34f;
            _healthBar.HealthBarUpdate(_health);
        }
    }
}
