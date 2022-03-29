using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{

    //панелька с сообщением о победе
    [SerializeField] GameObject winPanel;
    //эффект победы
    [SerializeField] GameObject winEffect;

    private void OnTriggerEnter(Collider other)
    {
        //при достижении финиша
        if (other.CompareTag("Player"))
        {
            //получаем индекс сцены
            int sceneID = SceneManager.GetActiveScene().buildIndex;
            //если это не последняя сцена
            if (sceneID < 3)
            {
                //сохраняем прогресс игрока
                SaveProgress(sceneID);
                //переходим на следующую сцену
                SceneManager.LoadScene(sceneID + 1);
            }
            //иначе поздравляем с победой
            else
            {
                //отключаем игрока, чтоб больше никуда не укатился
                other.gameObject.SetActive(false);
                winEffect.SetActive(true);
                winPanel.SetActive(true);
            }
        }
    }

    /// <summary>
    /// сохраняем прогресс игрока
    /// </summary>
    void SaveProgress(int sceneID)
    {
        //если нет сохраненного уровня, то этот будет первым
        if (!PlayerPrefs.HasKey("LevelPassed"))
        {
            PlayerPrefs.SetInt("LevelPassed", sceneID);
        }
        //если есть сохраненный уровень
        else
        {
            //если сохранен уровень ниже
            if (PlayerPrefs.GetInt("LevelPassed") < sceneID)
            {
                //пересохраняем
                PlayerPrefs.SetInt("LevelPassed", sceneID);
            }
        }
    }
}

