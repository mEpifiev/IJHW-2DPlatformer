using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _attackRange = 1.5f;
    [SerializeField] private float _attackCooldown = 2f;
    [SerializeField] private int _attackDamage = 10;

    private float _cooldownTimer;
    private Player _currentTarget;
    private EnemyAnimator _enemyAnimator;

    private void Awake()
    {
        _enemyAnimator = GetComponent<EnemyAnimator>();
        _cooldownTimer = _attackCooldown;
    }

    private void Update()
    {
        if (_cooldownTimer < _attackCooldown)
            _cooldownTimer += Time.deltaTime;

        if (_currentTarget != null && CanAttack())
            Attack();
    }

    public void SetTarget(Player target)
    {
        _currentTarget = target;
    }

    public void ClearTarget()
    {
        _currentTarget = null;
    }

    private bool CanAttack()
    {
        if (_currentTarget == null) 
            return false;

        float distanceToTarget = Vector2.Distance(transform.position, _currentTarget.transform.position);

        return distanceToTarget <= _attackRange && _cooldownTimer >= _attackCooldown;
    }

    private void Attack()
    {
        _cooldownTimer = 0f;

        if (_currentTarget.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_attackDamage);
            _enemyAnimator.SetAttackAnimation();
        }
    }
}
