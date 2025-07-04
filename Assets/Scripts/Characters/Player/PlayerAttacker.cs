using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(PlayerAnimator), typeof(EnemyDetector))]
public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _attackRange = 1.5f;
    [SerializeField] private float _attackCooldown = 2f;
    [SerializeField] private int _attackDamage = 10;

    private float _cooldownTimer;

    private InputReader _inputReader;
    private PlayerAnimator _playerAnimator;
    private EnemyDetector _enemyDetector;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _enemyDetector = GetComponent<EnemyDetector>();

        _cooldownTimer = _attackCooldown;
    }

    private void Update()
    {
        if (_cooldownTimer < _attackCooldown)
            _cooldownTimer += Time.deltaTime;

        if (_cooldownTimer >= _attackCooldown && _inputReader.AttackPressed)
            Attack();
    }

    private void Attack()
    {
        _cooldownTimer = 0f;
        _playerAnimator.SetAttackAnimation();

        if (_enemyDetector.TryGetEnemy(_attackRange, out IDamageable damageable))
            damageable.TakeDamage(_attackDamage);
    }
}
