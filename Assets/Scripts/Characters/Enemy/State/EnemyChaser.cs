using UnityEngine;

public class EnemyChaser : EnemyMover
{
    private Player _target;

    public void Chase(Player target)
    {
        _target = target;
    }

    public void StopChase()
    {
        _target = null;
        Stop();
    }

    private void FixedUpdate()
    {
        if (_target == null)
            return;

        Vector2 direction = (Vector2)_target.transform.position - Rigidbody2D.position;
        direction.y = 0;

        Move(direction);
    }
}
