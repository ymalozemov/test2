using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Joystick
{
    public class Controller : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        public RectTransform joystickHandle; // Ссылка на ручку джостика
        public float moveRange = 100f; // Радиус перемещения джостика

        private Vector2 _inputVector;

        private void Start()
        {
            // Убедитесь, что ручка джостика находится в центре
            joystickHandle.anchoredPosition = Vector2.zero;
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Получаем позицию джостика в локальных координатах
            Vector2 direction = eventData.position - (Vector2)joystickHandle.position;
            _inputVector = direction / moveRange;

            // Ограничиваем значение вектора
            if (_inputVector.magnitude > 1)
            {
                _inputVector.Normalize();
            }

            // Устанавливаем позицию ручки джостика
            joystickHandle.anchoredPosition = _inputVector * moveRange;
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
            _inputVector = Vector2.zero; // Обнуляем вектор ввода
            joystickHandle.anchoredPosition = Vector2.zero; // Возвращаем джостик в центр
        }

        public Vector2 GetInput()
        {
            return _inputVector; // Возвращаем текущее значение вектора ввода
        }
    }
}