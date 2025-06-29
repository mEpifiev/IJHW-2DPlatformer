using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoinPool))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Spawnpoint> _spawnpoints;

    private CoinPool _coinPool;

    private void Awake()
    {
        _coinPool = GetComponent<CoinPool>();

        Spawn();
    }

    private void Spawn()
    {
        List<Spawnpoint> availablePoints = new List<Spawnpoint>(_spawnpoints);

        int count = Mathf.Min(_coinPool.Capacity, availablePoints.Count);

        for (int i = 0; i < count; i++)
        {
            Coin newCoin = _coinPool.GetCoin();

            int randomSpawnpointIndex = Random.Range(0, availablePoints.Count);
            newCoin.transform.position = availablePoints[randomSpawnpointIndex].transform.position;

            availablePoints.RemoveAt(randomSpawnpointIndex);
        }
    }

    #if UNITY_EDITOR
    [ContextMenu("Refresh Child List")]
    private void RefreshChildList()
    {
        _spawnpoints = new();

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            if(child.TryGetComponent(out Spawnpoint spawnpoint))
                _spawnpoints.Add(spawnpoint);
        }
    }
    #endif
}
