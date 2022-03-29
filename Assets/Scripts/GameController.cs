using System;
using UnityEngine;

public static class GameController
{
    #region КЛЮЧ
    public static void KeyCollected()
    {
        PlayerPrefs.SetInt("Key", 1);
        OnKeyEvent?.Invoke(true);
    }
    public static void KeyUsed()
    {
        PlayerPrefs.SetInt("Key", 0);
        OnKeyEvent?.Invoke(false);
    }
    public static event Action<bool> OnKeyEvent;
    #endregion

    #region МОНЕТКА
    /// <summary>
    /// Монетка получена
    /// </summary>
    public static void CoinCollected()
    {
        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 1);
        }
        else
        {
            int currentCoins = PlayerPrefs.GetInt("Coins");
            PlayerPrefs.SetInt("Coins", ++currentCoins);
        }

        OnCoinsAmountChangedEvent?.Invoke(PlayerPrefs.GetInt("Coins"));
    }

    /// <summary>
    /// Монетка потрачена
    /// </summary>
    public static void CoinSpent()
    {
        int currentCoins = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.SetInt("Coins", --currentCoins);
        OnCoinsAmountChangedEvent?.Invoke(PlayerPrefs.GetInt("Coins"));
    }
    public static event Action<int> OnCoinsAmountChangedEvent;
    #endregion

    #region ЖИЗНЬ 
    /// <summary>
    /// Жизнь получена
    /// </summary>
    public static void HeartCollected()
    {
        if (!PlayerPrefs.HasKey("Hearts"))
        {
            PlayerPrefs.SetInt("Hearts", 1);
        }
        else
        {
            int currentHearts = PlayerPrefs.GetInt("Hearts");
            PlayerPrefs.SetInt("Hearts", ++currentHearts);
        }
        OnHeartsAmountChangedEvent?.Invoke(PlayerPrefs.GetInt("Hearts"));
    }

    /// <summary>
    /// Жизнь потрачена
    /// </summary>
    internal static void HeartSpent()
    {
        int currentHearts = PlayerPrefs.GetInt("Hearts");
        PlayerPrefs.SetInt("Hearts", --currentHearts);
        OnHeartsAmountChangedEvent?.Invoke(PlayerPrefs.GetInt("Hearts"));
    }
    public static event Action<int> OnHeartsAmountChangedEvent;
    #endregion

    #region ПОДСКАЗКА
    public static void ShowHint(string hint)
    {
        OnShowHintEvent?.Invoke(hint);
    }
    public static event Action<string> OnShowHintEvent;
    #endregion
}
