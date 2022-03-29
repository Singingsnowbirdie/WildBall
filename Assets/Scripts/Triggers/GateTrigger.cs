using System;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    /// <summary>
    /// Калитка
    /// </summary>
    Gate gate;

    /// <summary>
    /// Эти ворота открываются кнопкой
    /// </summary>
    [SerializeField] bool hasButton;

    private void OnEnable()
    {
        gate = GetComponentInParent<Gate>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //когда подходим к воротам
        if (other.CompareTag("Player"))
        {
            //если эти ворота открываются ключом
            if (!hasButton)
            {
                ShowKeyDialog();
            }
            //если эти ворота открываются кнопкой
            else
            {
                ShowButtonDialog();
            }
        }
    }

    /// <summary>
    /// Диалог для ворот с кнопкой
    /// </summary>
    private void ShowButtonDialog()
    {
        //показываем подсказку
        GameController.ShowHint($"This gate opens elsewhere.");
    }

    /// <summary>
    /// Когда игрок покидает триггер
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //нужно скрыть подсказку
            GameController.ShowHint("");
            //блокируем дверь, чтоб случайно не открыть ее
            gate.SetInteractable(false);
        }
    }

    /// <summary>
    /// Диалог для ворот с ключом
    /// </summary>
    void ShowKeyDialog()
    {
        //если в инвентаре есть ключ
        if (PlayerPrefs.HasKey("Key") && PlayerPrefs.GetInt("Key") == 1)
        {
            //делаем дверь "открывабельной"
            gate.SetInteractable(true);
            //показываем подсказку
            GameController.ShowHint($"You have a key. Press \"E\" to open the gate.");
        }
        //если в инвентаре нет ключа
        else
        {
            //дверь открыть нельзя
            gate.SetInteractable(false);
            //показываем подсказку
            GameController.ShowHint($"You need a key to open this gate.");
        }
    }
}
