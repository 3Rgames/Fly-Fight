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
        transform.localPosition = new Vector3(_target.localPosition.x - 0.8f, 1f, _target.localPosition.z + 0.03f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.HIT)
        {
            TapTicController.Instance.Medium();
            _health -= 10f;
            _healthBar.HealthBarUpdate(_health);
            if (_health <= 0)
                OnDeath?.Invoke();
        }
    }

    public void HealthBarInActive()
    {
        _healthBar.gameObject.SetActive(false);
    }
}
