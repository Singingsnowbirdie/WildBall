using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    /// <summary>
    /// Точка, куда будет перемещен игрок
    /// </summary>
    [SerializeField] Transform targetPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //перемещаем игрока
            other.gameObject.transform.position = targetPoint.transform.position;
        }
    }
}
