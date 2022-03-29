using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    //ворота, связанные с этой кнопкой
    [SerializeField] Gate gate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gate.Interact();
            //показываем подсказку
            GameController.ShowHint("It seems like a gate has opened somewhere.");
        }
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
        }
    }

}
