using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyDetector), typeof(InputReader))]
[RequireComponent(typeof(Health), typeof(EffectView))]
public class Vampirism : MonoBehaviour
{
    private const float Duration = 6f;
    private const float Cooldown = 4f;
    private const float DamagePerSecond = 5f;
    private const float Heal = 4f;

    [SerializeField] private float _radius;

    private EnemyDetector _enemyDetector;
    private InputReader _inputReader;
    private Health _health;
    private EffectView _view;

    private bool _isActive = false;
    private bool _isCooldown = false;

    private float _durationTimer = 0f;
    private float _cooldownTimer = 0f;

    public event Action<float> Activated;
    public event Action<float> Deactivated;

    public float Radius => _radius;

    private void Awake()
    {
        _enemyDetector = GetComponent<EnemyDetector>();
        _inputReader = GetComponent<InputReader>();
        _health = GetComponent<Health>();
        _view = GetComponent<EffectView>();
    }

    private void Update()
    {
        if(_inputReader.VampirismAbilityPressed && _isActive == false && _isCooldown == false)
            StartCoroutine(Activate());
    }

    private IEnumerator Activate()
    {
        _isActive = true;
        _durationTimer = 0f;
        _view.Play(transform.position);
        Activated?.Invoke(Duration);

        while(_durationTimer < Duration)
        {
            _durationTimer += Time.deltaTime;
            DealDamageToClosestEnemy(DamagePerSecond * Time.deltaTime);

            yield return null;
        }

        Deactivated?.Invoke(Cooldown);
        _isActive = false;
        _isCooldown = true;
        _cooldownTimer = 0f;

        while(_cooldownTimer < Cooldown)
        {
            _cooldownTimer += Time.deltaTime;

            yield return null;
        }

        _durationTimer = 0f;
        _isCooldown = false;
    }

    private void DealDamageToClosestEnemy(float damage)
    {
        int hitCounts = _enemyDetector.GetCountDetectedEnemies(_radius);

        if (hitCounts == 0)
            return;

        Transform closestEnemy = null;
        float closestSqrDistance = float.MaxValue;

        for (int i = 0; i < hitCounts; i++)
        {
            Transform enemy = _enemyDetector.DetectedEnemies[i].transform;
            float sqrDistance = (transform.position - enemy.position).sqrMagnitude;

            if (sqrDistance < closestSqrDistance)
            {
                closestSqrDistance = sqrDistance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && closestEnemy.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
            _health.Heal(Heal);
        }
    }
}
