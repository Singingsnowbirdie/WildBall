using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Interactable : MonoBehaviour
{
    /// <summary>
    /// Аниматор
    /// </summary>
    protected Animator anim;

    /// <summary>
    /// Можно взаимодействовать
    /// </summary>
    protected bool isInteractable;

    void OnEnable()
    {
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Запускает взаимодействие с объектом
    /// </summary>
    public virtual void Interact() { }

    /// <summary>
    /// Управляет интерактивностью объекта
    /// </summary>
    public void SetInteractable(bool value)
    {
        isInteractable = value;
    }
}
