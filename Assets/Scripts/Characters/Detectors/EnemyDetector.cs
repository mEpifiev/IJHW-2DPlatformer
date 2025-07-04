using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private LayerMask _attackableLayers;

    private Collider2D[] _attackResults = new Collider2D[3];
    private Transform _transform;

    public Collider2D[] DetectedEnemies => _attackResults;

    private void Awake()
    {
        _transform = transform;
    }

    public int GetCountDetectedEnemies(float radius)
    {
        return Physics2D.OverlapCircleNonAlloc(_transform.position, radius, _attackResults, _attackableLayers);
    }

    public bool TryGetEnemy(float detectionRange, out IDamageable damageable)
    {
        RaycastHit2D hit = Physics2D.Raycast(_raycastPoint.position, _raycastPoint.right, detectionRange, _attackableLayers);

        if (hit.collider != null)
            return hit.collider.TryGetComponent(out damageable);

        damageable = null;
        return false;
    }
}
