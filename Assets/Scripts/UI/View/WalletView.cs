using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _view;

    private void Awake()
    {
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
