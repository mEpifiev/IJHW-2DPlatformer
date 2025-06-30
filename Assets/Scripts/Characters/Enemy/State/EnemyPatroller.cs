using UnityEngine;

public class EnemyPatroller : EnemyMover
{
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _waitTime;

    private int _currentWaypointIndex = 0;
    private float _waitTimer = 0f;
    private bool _isWaiting;

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

            return;
        }

        MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        Vector2 direction = (Vector2)_waypoints[_currentWaypointIndex].transform.position - Rigidbody2D.position;
        direction.y = 0;

        Move(direction);

        if (Mathf.Abs(direction.x) <= StoppingDistance)
        {
            _isWaiting = true;
            Stop();

            return; 
        }

    }
}