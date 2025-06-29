using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _waitTime;

    private EnemyAnimator _enemyAnimator;

    private int _currentWaypointIndex = 0;
    private float _waitTimer = 0f;
    private float _reachThreshold = 0.05f;
    private bool _isWaiting;

    private void Awake()
    {
        _enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void Update()
    {
        if(_isWaiting)
        {
            _waitTimer += Time.deltaTime;

            if(_waitTimer >= _waitTime)
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
        
        currentPosition.x = Mathf.MoveTowards(currentPosition.x, target.position.x, _moveSpeed * Time.deltaTime);
        transform.position = currentPosition;

        _enemyAnimator.SetRunAnimation();

        if (Mathf.Abs(currentPosition.x - target.position.x) < _reachThreshold)
            _isWaiting = true;

        Flip(target);
    }

    private void Flip(Transform target)
    {
        Vector3 scale = transform.localScale;

        if (target.position.x > transform.position.x)
            scale.x = Mathf.Abs(scale.x);
        else
            scale.x = -Mathf.Abs(scale.x);

        transform.localScale = scale;
    }
}
