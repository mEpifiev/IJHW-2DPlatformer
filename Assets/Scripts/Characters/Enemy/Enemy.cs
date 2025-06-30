using UnityEngine;

[RequireComponent(typeof(EnemyPatroller), typeof(EnemyChaser), typeof(EnemyAttacker))]
[RequireComponent(typeof(PlayerDetector))]
public class Enemy : MonoBehaviour
{
    private EnemyPatroller _enemyPatroller;
    private EnemyChaser _enemyChaser;
    private EnemyAttacker _enemyAttacker;
    private PlayerDetector _playerDetector;

    private void Awake()
    {
        _enemyPatroller = GetComponent<EnemyPatroller>();
        _enemyChaser = GetComponent<EnemyChaser>();
        _enemyAttacker = GetComponent<EnemyAttacker>();
        _playerDetector = GetComponent<PlayerDetector>();
    }

    private void OnEnable()
    {
        _playerDetector.Detected += PlayerDetect;
        _playerDetector.Lost += PlayerLost;
    }

    private void OnDisable()
    {
        _playerDetector.Detected -= PlayerDetect;
        _playerDetector.Lost -= PlayerLost;
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
}
