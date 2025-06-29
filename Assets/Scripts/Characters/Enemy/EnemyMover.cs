using UnityEngine;

[RequireComponent(typeof(EnemyAnimator), typeof(Flipper))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _waitTime;

    private EnemyAnimator _enemyAnimator;
    private Flipper _flipper;

    private int _currentWaypointIndex = 0;
    private float _waitTimer = 0f;
    private float _reachThreshold = 0.05f;
    private bool _isWaiting;

    private void Awake()
    {
        _enemyAnimator = GetComponent<EnemyAnimator>();
        _flipper = GetComponent<Flipper>();
    }

    private void Update()
    {
        if (_isWaiting)
        {
            _waitTimer += Time.deltaTime;

            if (_waitTimer >= _waitTime)
            {
                _waitTimer = 0f;
                _isWaiting = false;

                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }

            _enemyAnimator.SetIdleAnimation();

            return;
        }

        MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        Transform target = _waypoints[_currentWaypointIndex].transform;

        Vector2 currentPosition = transform.position;
        float direction = target.position.x - currentPosition.x;

        currentPosition.x = Mathf.MoveTowards(currentPosition.x, target.position.x, _moveSpeed * Time.deltaTime);
        transform.position = currentPosition;

        _enemyAnimator.SetRunAnimation();

        if (Mathf.Abs(currentPosition.x - target.position.x) < _reachThreshold)
            _isWaiting = true;

        _flipper.Flip(direction);
    }
}