using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    /// <summary>
    /// Игра на паузе
    /// </summary>
    bool gameIsPaused;

    /// <summary>
    /// Уровень (он же индекс сцены)
    /// </summary>
    int levelNum;

    /// <summary>
    /// Счетчик монет
    /// </summary>
    [SerializeField] TextMeshProUGUI coinsCounter;

    /// <summary>
    /// Счетчик жизней
    /// </summary>
    [SerializeField] TextMeshProUGUI heartsCounter;

    /// <summary>
    /// Название уровня
    /// </summary>
    [SerializeField] TextMeshProUGUI levelText;

    /// <summary>
    /// Панель паузы
    /// </summary>
    [SerializeField] GameObject pausePanel;

    /// <summary>
    /// Текст подсказки
    /// </summary>
    [SerializeField] TextMeshProUGUI hintText;

    /// <summary>
    /// Изображение ключа
    /// </summary>
    [SerializeField] GameObject keyImage;

    private void OnEnable()
    {
        //инициализируем
        levelNum = SceneManager.GetActiveScene().buildIndex;

        //подписываемся
        GameController.OnCoinsAmountChangedEvent += ShowCoinsAmount;
        GameController.OnHeartsAmountChangedEvent += ShowHeartsAmount;
        GameController.OnShowHintEvent += ShowHint;
        GameController.OnKeyEvent += ShowKey;

        //отображаем нужную инфу
        levelText.text = $"Level {levelNum}";
        if (PlayerPrefs.HasKey("Coins"))
        {
            coinsCounter.text = PlayerPrefs.GetInt("Coins").ToString();
        }
        if (PlayerPrefs.HasKey("Hearts"))
        {
            heartsCounter.text = PlayerPrefs.GetInt("Hearts").ToString();
        }
        if (PlayerPrefs.HasKey("Key"))
        {
            if (PlayerPrefs.GetInt("Key") == 1)
            {
                keyImage.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Показывает/скрывает ключ
    /// </summary>
    private void ShowKey(bool value)
    {
        keyImage.SetActive(value);
    }

    /// <summary>
    /// Показывает количество запасных жизней
    /// </summary>
    /// <param name="obj"></param>
    private void ShowHeartsAmount(int amount)
    {
        heartsCounter.text = amount.ToString();
    }

    /// <summary>
    /// Показывает количество собранных монет
    /// </summary>
    /// <param name="amount"></param>
    private void ShowCoinsAmount(int amount)
    {
        coinsCounter.text = amount.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    /// <summary>
    /// Управляет паузой
    /// </summary>
    public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }

    /// <summary>
    /// Рестарт
    /// </summary>
    public void Restart()
    {
        //возвращаем время
        Time.timeScale = 1;
        //перезапускаем сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Выход в меню
    /// </summary>
    public void Exit()
    {
        //возвращаем время
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void OnDisable()
    {
        GameController.OnCoinsAmountChangedEvent -= ShowCoinsAmount;
        GameController.OnHeartsAmountChangedEvent -= ShowHeartsAmount;
        GameController.OnShowHintEvent += ShowHint;
        GameController.OnKeyEvent -= ShowKey;
    }

    /// <summary>
    /// Показывает подсказку
    /// </summary>
    private void ShowHint(string message)
    {
        hintText.text = message;
    }
}




