using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(PlayerAnimator))]
public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _attackRange = 1.5f;
    [SerializeField] private float _attackCooldown = 2f;
    [SerializeField] private int _attackDamage = 10;
    [SerializeField] private LayerMask _attackableLayers;

    private float _cooldownTimer;

    private InputReader _inputReader;
    private PlayerAnimator _playerAnimator;

    private Collider2D[] _attackResults = new Collider2D[5];

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _playerAnimator = GetComponent<PlayerAnimator>();

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

        int hitCounts = Physics2D.OverlapCircleNonAlloc(transform.position, _attackRange, _attackResults, _attackableLayers);

        for (int i = 0; i < hitCounts; i++)
            if (_attackResults[i].TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_attackDamage);
    }
}
