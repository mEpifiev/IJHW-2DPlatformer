using UnityEngine;

public class HealthBarRotation : MonoBehaviour
{
    private Quaternion _initialRotation;

    private void Awake()
    {
        _initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = _initialRotation;
    }
}
