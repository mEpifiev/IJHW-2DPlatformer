using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private float _value;

    public event Action<Coin> PickUp;

    public void Collect(Collector collector)
    {
        collector.Wallet.AddCoin(_value);
        PickUp?.Invoke(this);
    }
}
