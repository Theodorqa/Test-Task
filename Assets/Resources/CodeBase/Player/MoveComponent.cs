using System;
using Resources.CodeBase.Player;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveComponent : MonoBehaviour
{
    [SerializeField] private InputComponent _inputComponent; // Компонент для распознования ввода пользователя
    
    // Данные объекта, которого будем двигать
    [Range(1f, 10f)]
    public float speed;
    private Rigidbody _rigidbody;
    private Vector3 _moveVelocity; // конечная скорость объекта
    public bool isMoving = false; // флажок для анимации
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); // получаем компонент
    }

    private void Update()
    {
        _moveVelocity = _inputComponent.moveInput.normalized * speed; // конечная нормализованная скорость
        
        if (_moveVelocity != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, _moveVelocity, Time.deltaTime * 10f); // поворот в сторону движения
        }
        
        PlayerIsMoving(); // проверка, движется ли объект
        
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _moveVelocity * Time.fixedDeltaTime); // движение объекта
    }

    private void PlayerIsMoving()
    {
        bool isMovingHorizontal = Math.Abs(_inputComponent.moveInput.x) != 0f;
        bool isMovingVertical = Math.Abs(_inputComponent.moveInput.z) != 0f;

        bool isJoystickMoving = _inputComponent.joystick.Horizontal != 0 || _inputComponent.joystick.Vertical != 0;

        isMoving = isMovingHorizontal || isMovingVertical || isJoystickMoving;
    }
}
