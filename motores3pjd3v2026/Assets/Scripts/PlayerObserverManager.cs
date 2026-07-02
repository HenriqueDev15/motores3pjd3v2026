using System;

public static class PlayerObserverManager
{
    public static Action<int> OnCoinChanged;

    public static void NotifyCoinChanged(int coins)
    {
        OnCoinChanged?.Invoke(coins);
    }
}