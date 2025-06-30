using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth;

    public float CurrentHealth { get; private set; }

    public event Action<float> Changed;
    public event Action Died;

    private void Awake()
    {
        CurrentHealth = _maxHealth;

        Changed?.Invoke(CurrentHealth);
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

        CurrentHealth = Mathf.Max(0, CurrentHealth - damage);

        Changed?.Invoke(CurrentHealth);

        if (CurrentHealth <= 0)
            Die();
    }

    public void Heal(float amount)
    {
        if (amount <= 0)
            return;

        CurrentHealth = Mathf.Min(_maxHealth, CurrentHealth + amount);

        Changed?.Invoke(CurrentHealth);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
