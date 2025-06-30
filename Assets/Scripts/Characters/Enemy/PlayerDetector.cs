using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private float _detectionRange = 5f;
    [SerializeField] private LayerMask _layerMask;

    public event Action<Player, float> Detected;
    public event Action Lost;

    private Player _currentPlayer;

    private void Update()
    {
        if (_raycastPoint == null) 
            return;

        DetectPlayer();
    }

    private void DetectPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(_raycastPoint.position, _raycastPoint.right, _detectionRange, _layerMask);

        Player detectedPlayer = null;
        float distanceToPlayer = 0f;

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out detectedPlayer))
            {
                distanceToPlayer = Vector2.Distance(_raycastPoint.position, hit.point);
            }
        }

        if (_currentPlayer != detectedPlayer)
        {
            if (_currentPlayer != null)
            {
                Lost?.Invoke();
            }

            _currentPlayer = detectedPlayer;

            if (_currentPlayer != null)
            {
                Detected?.Invoke(_currentPlayer, distanceToPlayer);
            }
        }

        else if (_currentPlayer != null)
        {
            float currentDistance = Vector2.Distance(_raycastPoint.position, hit.point);
            Detected?.Invoke(_currentPlayer, currentDistance);
        }
    }
}