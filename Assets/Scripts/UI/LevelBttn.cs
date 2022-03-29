using UnityEngine;
using UnityEngine.SceneManagement;

//кнопка загрузки уровня

public class LevelBttn : MonoBehaviour
{
    /// <summary>
    /// уровень
    /// </summary>
    [SerializeField] int level;

    /// <summary>
    /// Кнопка нажата
    /// </summary>
    public void BttnPressed()
    {
        //если этот уровень уже открыт
        if (PlayerPrefs.HasKey("LevelPassed") && PlayerPrefs.GetInt("LevelPassed") <= level)
        {
            //загружаем его
            SceneManager.LoadScene(level);
        }
        //делаем исключение для первого уровня
        else if (level == 1)
        {
            //загружаем его
            SceneManager.LoadScene(level);
        }
    }
}
