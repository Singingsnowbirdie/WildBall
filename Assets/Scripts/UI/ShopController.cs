using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    /// <summary>
    /// количество жизней у игрока
    /// </summary>
    [SerializeField] TextMeshProUGUI heartsCounter;

    /// <summary>
    /// количество монет у игрока
    /// </summary>
    [SerializeField] TextMeshProUGUI coinsCounter;

    /// <summary>
    /// Кнопка покупки
    /// </summary>
    [SerializeField] Button buyButton;

    int coins;
    int hearts;

    private void OnEnable()
    {
        ShowDeposit();
    }

    /// <summary>
    /// Обновляет данные о монетах и жизнях
    /// </summary>
    private void UpdateDeposit()
    {
        if (PlayerPrefs.HasKey("Coins")) coins = PlayerPrefs.GetInt("Coins");
        if (PlayerPrefs.HasKey("Hearts")) hearts = PlayerPrefs.GetInt("Hearts");
    }

    /// <summary>
    /// Показать количество монет и жизней
    /// </summary>
    private void ShowDeposit()
    {
        UpdateDeposit();

        if (coins >= 10) buyButton.interactable = true;
        else buyButton.interactable = false;
        coinsCounter.text = coins.ToString();
        heartsCounter.text = hearts.ToString();
    }

    /// <summary>
    /// Нажата кнопка покупки
    /// </summary>
    public void BttnPress()
    {
        PlayerPrefs.SetInt("Coins", coins - 10);
        PlayerPrefs.SetInt("Hearts", ++hearts);
        ShowDeposit();
    }
}
