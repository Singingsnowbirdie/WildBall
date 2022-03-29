using UnityEngine;

public class Coin : Gatherable
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
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    public override void Interact()
    {
        GameController.CoinCollected();
        anim.SetTrigger("Collected");
        Destroy(gameObject, 0.6f);
    }
}
