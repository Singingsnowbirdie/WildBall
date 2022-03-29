using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    /// <summary>
    /// Панель главного меню
    /// </summary>
    [SerializeField] GameObject mainPanel;

    /// <summary>
    /// Панель выбора уровня
    /// </summary>
    [SerializeField] GameObject levelSelectionPanel;

    /// <summary>
    /// Панель информации
    /// </summary>
    [SerializeField] GameObject infoPanel;

    /// <summary>
    /// Индикаторы уровней
    /// </summary>
    [SerializeField] List<Image> levelIndicators;

    /// <summary>
    /// Последний открытый уровень
    /// </summary>
    int levelPassed;

    /// <summary>
    /// Красный индикатор
    /// </summary>
    [SerializeField] Sprite redIndicator;

    /// <summary>
    /// Зеленый индикатор
    /// </summary>
    [SerializeField] Sprite greenIndicator;

    private void Awake()
    {
        //"вспоминаем" последний пройденный уровень
        if (PlayerPrefs.HasKey("LevelPassed"))
        {
            levelPassed = PlayerPrefs.GetInt("LevelPassed");
        }

        //пробегаемся по всем индикаторам
        for (int i = 0; i < levelIndicators.Count; i++)
        {
            //если этот уровень открыт, "включаем" зеленую лампочку
            if (i <= levelPassed)
            {
               
                levelIndicators[i].sprite = greenIndicator;
            }
            //иначе "включаем" красную лампочку
            else
            {
                levelIndicators[i].sprite = redIndicator;
            }
        }
    }

    /// <summary>
    /// Выход
    /// </summary>
    public void Exit()
    {
        Debug.Log("Application.Quit");
        Application.Quit();
    }
}
