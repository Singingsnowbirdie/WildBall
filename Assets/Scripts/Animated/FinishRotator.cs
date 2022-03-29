using UnityEngine;

public class FinishRotator : MonoBehaviour
{
    /// <summary>
    /// Скорость поворота
    /// </summary>
    [SerializeField] float speed;

	void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
