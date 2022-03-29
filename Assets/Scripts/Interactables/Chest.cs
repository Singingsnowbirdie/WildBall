using UnityEngine;

public class Chest : Interactable
{
    /// <summary>
    /// Сундук открыт
    /// </summary>
    bool isOpened;

    /// <summary>
    /// Система частиц
    /// </summary>
    [SerializeField] ParticleSystem ps;

    private void Awake()
    {
        SetInteractable(true);
    }

    public override void Interact()
    {
        GameController.HeartCollected();
        anim.SetTrigger("OnChestGathered");
        ps.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isOpened)
            {
                isOpened = true;
                Interact();
            }
        }
    }
}
