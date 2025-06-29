using UnityEngine;

public class Flipper : MonoBehaviour
{
    private bool _facingRight = true;

    public void Flip(float direction)
    {
        if (direction > 0 && _facingRight == false)
        {
            transform.Rotate(0f, 180f, 0f);
            _facingRight = true;
        }
        else if (direction < 0 && _facingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            _facingRight = false;
        }
    }
}
