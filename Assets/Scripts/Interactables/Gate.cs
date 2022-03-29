using UnityEngine;

public class Gate : Interactable
{
    /// <summary>
    /// Триггер
    /// </summary>
    [SerializeField] GameObject trigger;

    public override void Interact()
    {
        //показываем анимацию
        anim.SetTrigger("OnGateOpened");
        //отключаем триггер (на всякий случай, вдруг что еще залетит)
        trigger.SetActive(false);
        //выключаем подсказку
        GameController.ShowHint($"");
        //обнуляем ключ
        PlayerPrefs.SetInt("Key", 0);
        //сообщаем UI, что больше не нужно отображать ключ
        GameController.KeyUsed();
    }

    private void Update()
    {
        //отслеживаем нажаатие кнопки "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInteractable)
            {
                Interact();
            }
        }
    }
}
