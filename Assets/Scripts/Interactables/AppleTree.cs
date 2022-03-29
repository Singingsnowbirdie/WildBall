using UnityEngine;

public class AppleTree : Interactable
{

    private void Awake()
    {
        SetInteractable(true);
    }

    public override void Interact()
    {
        GameController.HeartCollected();
        anim.SetTrigger("OnAppleGathered");
    }

    /// <summary>
    /// При столкновении с коллайдером игрока
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isInteractable)
            {
                SetInteractable(false);
                Interact();
            }
        }
    }
}
