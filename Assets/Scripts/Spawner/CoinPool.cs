using UnityEngine;
using UnityEngine.Pool;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private Transform _container; 
    [SerializeField] private Coin _prefab;
    [SerializeField] private int _capacity;
    [SerializeField] private int _maxSize;

    private ObjectPool<Coin> _pool;

    public int Capacity => _capacity;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
            createFunc: () => Instantiate(_prefab, _container),
            actionOnGet: (coin) => Get(coin),
            actionOnRelease: (coin) => Release(coin),
            actionOnDestroy: (coin) => Destroy(coin.gameObject),
            collectionCheck: true, 
            defaultCapacity: _capacity, 
            maxSize: _maxSize);
    }

    public Coin GetCoin() => _pool.Get();

    public void ReleaseCoin(Coin coin) => _pool.Release(coin);

    private void Get(Coin coin)
    {
        coin.PickUp += Release;
        coin.gameObject.SetActive(true);
    }

    private void Release(Coin coin)
    {
        coin.PickUp -= Release;
        coin.gameObject.SetActive(false);
    }
}
