using TMPro;
using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();

        _view.text = _wallet.Coins.ToString();
    }

    private void OnEnable()
    {
        _wallet.CoinChanged += DisplayWallet;
    }

    private void OnDisable()
    {
        _wallet.CoinChanged -= DisplayWallet;
    }

    private void DisplayWallet()
    {
        _view.text = _wallet.Coins.ToString();
    }
}
