using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;

    private void FixedUpdate()
    {
        _mover?.Move();
        _jumper?.Jump();
    }
}
