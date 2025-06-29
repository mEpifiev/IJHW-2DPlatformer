using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private float _coins;

    public event Action<float> CoinChanged;

    public float Coins => _coins;

    public void AddCoin(float amoumt)
    {
        if (amoumt < 0)
            return;

        _coins += amoumt;

        CoinChanged?.Invoke(_coins);
    }
}
