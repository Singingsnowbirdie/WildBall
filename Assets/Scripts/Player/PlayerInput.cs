using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    /// <summary>
    /// Направление движения
    /// </summary>
    Vector3 direction;

    /// <summary>
    /// Класс, двигающий персонажа
    /// </summary>
    PlayerMovement movement;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();    
    }

    private void Update()
    {
        //получаем значения ввода
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //вычисляем направление движения
        direction = new Vector3(horizontal, 0, vertical).normalized;
    }

    private void FixedUpdate()
    {
        movement.MoveCharacter(direction);
    }
}
