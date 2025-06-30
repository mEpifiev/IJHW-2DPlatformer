using UnityEngine;

[RequireComponent(typeof(EnemyPatroller), typeof(EnemyChaser), typeof(PlayerDetector))]
public class Enemy : MonoBehaviour
{
    private EnemyPatroller _enemyPatroller;
    private EnemyChaser _enemyChaser;
    private PlayerDetector _playerDetector;

    private void Awake()
    {
        _enemyPatroller = GetComponent<EnemyPatroller>();
        _enemyChaser = GetComponent<EnemyChaser>();
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

    private void PlayerDetect(Player player, float distance)
    {
        _enemyPatroller.enabled = false;
        _enemyChaser.Chase(player);
    }
    private void PlayerLost()
    {
        _enemyChaser.StopChase();
        _enemyPatroller.enabled = true;
    }
}
