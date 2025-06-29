using UnityEngine;

[RequireComponent(typeof(Coin))]
public class CoinView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private Coin _coin;

    private void Awake()
    {
        _coin = GetComponent<Coin>();
    }

    private void OnEnable()
    {
        _coin.PickUp += Play;
    }

    private void OnDisable()
    {
        _coin.PickUp -= Play;
    }

    private void Play(Coin coin)
    {
        if (_effect == null)
            return;

        ParticleSystem effect = Instantiate(_effect, coin.transform.position, transform.rotation);

        effect.Play(_effect);

        Destroy(effect.gameObject, effect.main.duration + effect.main.startLifetime.constantMax);
    }
}
