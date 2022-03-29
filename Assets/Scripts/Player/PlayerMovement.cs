using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //необходимый компонент (обезопасили от удаления)
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Тело
    /// </summary>
    Rigidbody rb;

    /// <summary>
    /// Скорость
    /// </summary>
    [SerializeField, Range(0, 10)] float speed = 2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Двигаем персонажа
    /// </summary>
    public void MoveCharacter(Vector3 direction)
    {
        rb.AddForce(direction * speed);
    }

#if UNITY_EDITOR
    /// <summary>
    /// Возвращает значения по умолчанию
    /// </summary>
    [ContextMenu("Reset values")] //чтобы этот метод стал доступен из инспектора
    public void ResetValues()
    {
        speed = 2f;
    }
#endif
}
