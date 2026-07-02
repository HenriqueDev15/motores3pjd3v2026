using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void OnEnable()
    {
        PlayerObserverManager.OnCoinChanged += UpdateCoins;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnCoinChanged -= UpdateCoins;
    }

    void UpdateCoins(int value)
    {
        coinText.text = "Moedas: " + value;
    }
}