using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Jump = nameof(Jump);

    public float HorizontalDirection {  get; private set; }
    public bool JumpButtonPressed {  get; private set; }

    private void Update()
    {
        HorizontalDirection = Input.GetAxis(Horizontal);
        JumpButtonPressed = Input.GetButtonDown(Jump);
    }
}
