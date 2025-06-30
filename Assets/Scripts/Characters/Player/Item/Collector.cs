using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Health _health;

    public Wallet Wallet => _wallet;
    public Health Health => _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out ICollectable collectable))
            collectable.Collect(this);
    }
}
