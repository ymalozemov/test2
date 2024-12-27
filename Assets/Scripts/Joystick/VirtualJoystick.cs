using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform joystickHandle; // Ссылка на ручку джостика
    public float moveRange = 100f; // Радиус перемещения джостика

    private Vector2 inputVector;

    private void Start()
    {
        // Убедитесь, что ручка джостика находится в центре
        joystickHandle.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Получаем позицию джостика в локальных координатах
        Vector2 direction = eventData.position - (Vector2)joystickHandle.position;
        inputVector = direction / moveRange;

        // Ограничиваем значение вектора
        if (inputVector.magnitude > 1)
        {
            inputVector.Normalize();
        }

        // Устанавливаем позицию ручки джостика
        joystickHandle.anchoredPosition = inputVector * moveRange;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Устанавливаем начальное положение джостика
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)transform, 
            eventData.position, 
            eventData.pressEventCamera, 
            out localPoint
        );

        joystickHandle.anchoredPosition = localPoint; // Устанавливаем начальную позицию
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero; // Обнуляем вектор ввода
        joystickHandle.anchoredPosition = Vector2.zero; // Возвращаем джостик в центр
    }

    public Vector2 GetInput()
    {
        return inputVector; // Возвращаем текущее значение вектора ввода
    }
}