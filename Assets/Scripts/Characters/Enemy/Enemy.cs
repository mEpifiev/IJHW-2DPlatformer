using UnityEngine;

[RequireComponent(typeof(EnemyPatroller), typeof(EnemyChaser), typeof(EnemyAttacker))]
[RequireComponent(typeof(PlayerDetector), typeof(EnemyAnimator))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private EnemyPatroller _enemyPatroller;
    private EnemyChaser _enemyChaser;
    private EnemyAttacker _enemyAttacker;
    private PlayerDetector _playerDetector;
    private EnemyAnimator _enemyAnimator;
    private Health _health;

    private float _deathDelay = 1f;

    private void Awake()
    {
        _enemyPatroller = GetComponent<EnemyPatroller>();
        _enemyChaser = GetComponent<EnemyChaser>();
        _enemyAttacker = GetComponent<EnemyAttacker>();
        _playerDetector = GetComponent<PlayerDetector>();
        _enemyAnimator = GetComponent<EnemyAnimator>();
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
        _enemyPatroller.enabled = false;
        _enemyChaser.enabled = false;
        _enemyAttacker.enabled = false;

        _enemyAnimator.SetDeathAnimation();

        Destroy(gameObject, _deathDelay);
    }
}
