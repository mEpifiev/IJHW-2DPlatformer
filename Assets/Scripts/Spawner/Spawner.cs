using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected List<Spawnpoint> Spawnpoints;

    protected GameObjectPool<T> GameObjectPool;

    protected void Spawn()
    {
        List<Spawnpoint> availablePoints = new List<Spawnpoint>(Spawnpoints);

        int count = Mathf.Min(GameObjectPool.Capacity, availablePoints.Count);

        for (int i = 0; i < count; i++)
        {
            T gameObj = GameObjectPool.Get();

            int randomSpawnpointIndex = Random.Range(0, availablePoints.Count);
            gameObj.transform.position = availablePoints[randomSpawnpointIndex].transform.position;

            availablePoints.RemoveAt(randomSpawnpointIndex);
        }
    }
}