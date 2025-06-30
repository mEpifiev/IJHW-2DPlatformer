using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private float _detectionRange = 5f;
    [SerializeField] private LayerMask _layerMask;

    public event Action<Player> Detected;
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

        if (hit.collider != null)
        {
            hit.collider.TryGetComponent(out detectedPlayer);
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
                Detected?.Invoke(_currentPlayer);
            }
        }
    }
}