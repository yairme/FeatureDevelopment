using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    protected float _currentHealth;
    protected float _startingHealth = 100;

    protected virtual void Start()
    {
        _currentHealth = _startingHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Dead();
        }
    }

    public float GetnormalizedHealth()
    {
        return _currentHealth;
    }

    protected virtual void Dead()
    {
        print("I'm dead");
    }
}
