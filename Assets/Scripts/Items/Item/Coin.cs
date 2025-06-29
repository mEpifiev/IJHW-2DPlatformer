using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private float _value;

    public void Collect(Collector collector)
    {
        collector.Wallet.AddCoin(_value);
    }
}
