using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Стартовая точка
    /// </summary>
    Vector3 startPoint;

    /// <summary>
    /// Точка сохранения
    /// </summary>
    GameObject savePoint;

    /// <summary>
    /// Система частиц
    /// </summary>
    [SerializeField] GameObject ps;

    private void OnEnable()
    {
        startPoint = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        //при падении с платформы
        if (other.CompareTag("FallingTrigger"))
        {
            StartCoroutine(Death());
        }
        //При соприкосновении с точкой сохранения
        else if (other.CompareTag("SavePoint"))
        {
            //запоминаем ее
            savePoint = other.gameObject;
        }
    }

    IEnumerator Death()
    {
        //отключаем рендер игрока
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        //перемещаем эффект смерти, чтоб он сработал на месте исчезновения игрока
        ps.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //показываем эффект смерти
        ps.SetActive(true);
        yield return new WaitForSeconds(5);
        //перезапускаем сцену
        Restart();
    }

    private void Restart()
    {
        //если у игрока есть запасные жизни и запомненная точка сохранения
        if (PlayerPrefs.HasKey("Hearts") && PlayerPrefs.GetInt("Hearts") > 0 && savePoint != null)
        {
            //тратим жизнь
            GameController.HeartSpent();
            //помещаем игрока на место поcледнего сохранения
            transform.position = savePoint.transform.position;
        }
        else
        {
            //помещаем игрока на стартовую точку
            transform.position = startPoint;
        }
            //включаем рендер игрока
            gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}

