using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Персонаж, за которым будет следить камера
    public Vector3 offset; // Смещение камеры относительно персонажа

    private void Start()
    {
        target = FindFirstObjectByType<Player.PlayerMovement>().transform;

        // Установите смещение, если оно не задано
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 5, -10); // Пример смещения для изометрической камеры
        }
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
    }
}