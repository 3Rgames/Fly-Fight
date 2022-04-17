using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTrigger : MonoBehaviour
{
    public event Action OnDeath;

    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Transform _target;
    private float _health = 100f;

    private void FixedUpdate()
    {
        transform.position = _target.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.SWORD)
        {
            TapTicController.Instance.Light();
            _health -= 34f;
            _healthBar.HealthBarUpdate(_health);
            if (_health <= 0)
            {
                OnDeath?.Invoke();
                Destroy(GetComponent<Rigidbody>());
                Destroy(GetComponent<CapsuleCollider>());
            }
        }
    }

    public void HealthBarInActive()
    {
        _healthBar.gameObject.SetActive(false);
    }
}
