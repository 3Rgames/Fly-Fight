using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTrigger : MonoBehaviour
{
    public event Action OnDeath;

    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Transform _target;
    private float _health = 100f;

    private void FixedUpdate()
    {
        transform.localPosition = _target.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.HIT)
        {
            TakeDamage(10f);
        }
        if(other.tag == Tags.SEA)
        {
            TakeDamage(100f);
        }
    }

    private void TakeDamage(float damage)
    {
        TapTicController.Instance.Medium();
        _health -= damage;
        _healthBar.HealthBarUpdate(_health);
        if (_health <= 0)
            OnDeath?.Invoke();
    }

    public void HealthBarInActive()
    {
        _healthBar.gameObject.SetActive(false);
    }
}
