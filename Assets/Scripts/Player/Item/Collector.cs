using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    public Wallet Wallet => _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out ICollectable collectable))
            collectable.Collect(this);
    }
}
