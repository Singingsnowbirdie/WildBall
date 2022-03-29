using UnityEngine;

public class Gatherable : Interactable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isInteractable)
            {
                SetInteractable(false);
                Interact();
            }
        }
    }
}
