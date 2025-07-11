using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable, IMedicinable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] float _currentHealth;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    public event Action<float> Changed;
    public event Action Died;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void OnValidate()
    {
        if (_maxHealth <= 0)
            _maxHealth = 1;
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0)
            return;

        _currentHealth = Mathf.Max(0, _currentHealth - damage);

        Changed?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
            Die();
    }

    public void Heal(float amount)
    {
        if (amount <= 0)
            return;

        _currentHealth = Mathf.Min(_maxHealth, _currentHealth + amount);

        Changed?.Invoke(_currentHealth);
    }

    public void Die()
    {
        Died?.Invoke();
    }
}