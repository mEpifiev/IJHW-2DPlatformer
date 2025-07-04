using UnityEngine;

[RequireComponent(typeof(Health), typeof(PlayerAnimator))]
[RequireComponent(typeof(CapsuleCollider2D), typeof(InputReader), typeof(Mover))]
public class Player : MonoBehaviour
{
    private Health _health;
    private CapsuleCollider2D _capsuleCollider2D;
    private PlayerAnimator _playerAnimator;
    private InputReader _inputReader;
    private Mover _mover;

    public Health Health => _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        _health.Died += HandleDeath;
    }

    private void OnDisable()
    {
        _health.Died -= HandleDeath;
    }

    private void HandleDeath()
    {
        _inputReader.enabled = false;
        _capsuleCollider2D.enabled = false;
        _mover.enabled = false;

        _playerAnimator.SetDeathAnimation();
    }
}
