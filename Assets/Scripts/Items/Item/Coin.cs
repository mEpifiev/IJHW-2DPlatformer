using System;
using UnityEngine;

[RequireComponent(typeof(EffectView))]
public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private float _value;

    private EffectView _view;

    public event Action<Coin> PickUp;

    private void Awake()
    {
        _view = GetComponent<EffectView>();
    }

    public void Collect(Collector collector)
    {
        collector.Wallet.AddCoin(_value);
        _view.Play(transform.position);

        PickUp?.Invoke(this);
    }
}
