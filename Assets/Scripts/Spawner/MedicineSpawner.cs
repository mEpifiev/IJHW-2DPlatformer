using UnityEngine;

[RequireComponent(typeof(MedicinePool))]
public class MedicineSpawner : Spawner<Medicine>
{
    private void Awake()
    {
        GameObjectPool = GetComponent<MedicinePool>();
    }

    private void Start()
    {
        Spawn();
    }

#if UNITY_EDITOR
    [ContextMenu("Refresh Child List")]
    private void RefreshChildList()
    {
        Spawnpoints = new();

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            if (child.TryGetComponent(out Spawnpoint spawnpoint))
                Spawnpoints.Add(spawnpoint);
        }
    }
#endif
}