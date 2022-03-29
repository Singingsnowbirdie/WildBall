using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    /// <summary>
    /// Игрок
    /// </summary>
    [SerializeField] Transform player;

    /// <summary>
    /// Поправка на смещение камеры, относительно игрока
    /// </summary>
    Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    private void FixedUpdate()
    {
        transform.position = player.position + offset;
    }
}
