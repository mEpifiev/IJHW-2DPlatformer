using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Quaternion _rightRotate = Quaternion.Euler(new Vector2(0f, 0f));
    private Quaternion _leftRotate = Quaternion.Euler(new Vector2(0f, 180f));

    private bool _facingRight = true;

    public void Flip(float direction)
    {
        if (direction > 0 && _facingRight == false)
        {
            transform.rotation = _rightRotate;
            _facingRight = true;
        }
        else if (direction < 0 && _facingRight)
        {
            transform.rotation = _leftRotate;
            _facingRight = false;
        }
    }
}
