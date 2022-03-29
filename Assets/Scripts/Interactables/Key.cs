using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Gatherable
{
    /// <summary>
    /// Скорость поворота
    /// </summary>
    [SerializeField] float speed;

    private void Awake()
    {
        SetInteractable(true);
    }

    void Update()
    {
        transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }

    public override void Interact()
    {
        GameController.KeyCollected();
        anim.SetTrigger("Collected");
        Destroy(gameObject, 0.6f);
    }
}
