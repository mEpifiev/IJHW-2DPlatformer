public class CoinPool : GameObjectPool<Coin>
{
    protected override void OnGetObject(Coin coin)
    {
        base.OnGetObject(coin);
        coin.PickUp += OnCoinPickedUp;
    }

    protected override void OnReleaseObject(Coin coin)
    {
        coin.PickUp -= OnCoinPickedUp;
        base.OnReleaseObject(coin);
    }

    private void OnCoinPickedUp(Coin coin)
    {
        Release(coin);
    }
}