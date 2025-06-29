using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(InputReader), typeof(Flipper))]
[RequireComponent(typeof(PlayerAnimator))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody2D;
    private InputReader _inputReader;
    private Flipper _flipper;
    private PlayerAnimator _playerAnimator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();
        _flipper = GetComponent<Flipper>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    public void FixedUpdate()
    {
        float direction = _inputReader.HorizontalDirection;

        _rigidbody2D.velocity = new Vector2(direction * _moveSpeed, _rigidbody2D.velocity.y);

        _flipper.Flip(direction);

        if (Mathf.Abs(direction) > 0.01f)
            _playerAnimator.SetRunAnimation();
        else
            _playerAnimator.SetIdleAnimation();
    }
}
