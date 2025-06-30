using UnityEngine;

[RequireComponent(typeof(EnemyAnimator), typeof(Flipper), typeof(Rigidbody2D))]
public abstract class EnemyMover : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] protected float StoppingDistance;

    protected Rigidbody2D Rigidbody2D;
    protected EnemyAnimator EnemyAnimator;

    private Flipper _flipper;

    protected virtual void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        EnemyAnimator = GetComponent<EnemyAnimator>();
        _flipper = GetComponent<Flipper>();
    }

    protected virtual void Move(Vector2 direction)
    {
        if(direction.magnitude > StoppingDistance)
        {
            Rigidbody2D.velocity = direction.normalized * Speed;
            _flipper.Flip(direction.x);
            EnemyAnimator.SetRunAnimation();
        }
        else
        {
            Stop();
        }
    }

    protected void Stop()
    {
        Rigidbody2D.velocity = Vector2.zero;
        EnemyAnimator.SetIdleAnimation();
    }
}
