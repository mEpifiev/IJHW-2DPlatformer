using UnityEngine;

[RequireComponent(typeof(EnemyPatroller), typeof(EnemyChaser), typeof(EnemyAttacker))]
[RequireComponent(typeof(PlayerDetector), typeof(EnemyAnimator))]
[RequireComponent(typeof(Health), typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private EnemyPatroller _enemyPatroller;
    private EnemyChaser _enemyChaser;
    private EnemyAttacker _enemyAttacker;
    private PlayerDetector _playerDetector;
    private EnemyAnimator _enemyAnimator;
    private Rigidbody2D _rigidbody2D;
    private Health _health;

    private float _deathDelay = 0.5f;

    private void Awake()
    {
        _enemyPatroller = GetComponent<EnemyPatroller>();
        _enemyChaser = GetComponent<EnemyChaser>();
        _enemyAttacker = GetComponent<EnemyAttacker>();
        _playerDetector = GetComponent<PlayerDetector>();
        _enemyAnimator = GetComponent<EnemyAnimator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _playerDetector.Detected += PlayerDetect;
        _playerDetector.Lost += PlayerLost;
        _health.Died += HandleDeath;
    }

    private void OnDisable()
    {
        _playerDetector.Detected -= PlayerDetect;
        _playerDetector.Lost -= PlayerLost;
        _health.Died -= HandleDeath;
    }

    private void PlayerDetect(Player player)
    {
        _enemyPatroller.enabled = false;
        _enemyChaser.Chase(player);
        _enemyAttacker.SetTarget(player);
    }
    private void PlayerLost()
    {
        _enemyChaser.StopChase();
        _enemyPatroller.enabled = true;
        _enemyAttacker.ClearTarget();
    }

    private void HandleDeath()
    {
        _rigidbody2D.simulated = false;

        _enemyAnimator.SetDeathAnimation();

        Destroy(gameObject, _deathDelay);
    }
}
