using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Цель, за которой должна двигаться камера
    public float smoothSpeed = 0.125f; // Скорость плавного движения камеры

    private Vector3 offset; // Смещение камеры относительно цели

    void Start()
    {
        offset = transform.position - target.position; // Вычисляем начальное смещение камеры
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Вычисляем желаемую позицию камеры
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Применяем плавное движение с использованием Lerp

        transform.position = smoothedPosition; // Обновляем позицию камеры
    }
}