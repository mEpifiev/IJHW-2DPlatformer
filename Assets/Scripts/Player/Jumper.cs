using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputReader))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody2D;
    private InputReader _inputReader;

    private bool _isJumping = false;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        if (_inputReader.JumpButtonPressed && IsGrounded())
            _isJumping = true;
    }

    public void Jump()
    {
        if (_isJumping == false)
            return;

        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        _isJumping = false;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }
}
