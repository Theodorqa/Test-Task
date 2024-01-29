using System;
using UnityEngine;
using Zenject;

namespace Resources.CodeBase.Main_Scene.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveComponent : MonoBehaviour
    {
        [Inject] private InputComponent _inputComponent; // Компонент для распознования ввода пользователя

        // Данные объекта, которого будем двигать
        [SerializeField] private float speed;


        public bool isMoving; // флажок для анимации

        private Vector3 _moveVelocity; // конечная скорость объекта
        private Rigidbody _rigidbody;

        #region  Mono

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
        #endregion

        #region User Methods

        private void PlayerIsMoving()
        {
            bool isMovingHorizontal = Math.Abs(_inputComponent.moveInput.x) != 0f;
            bool isMovingVertical = Math.Abs(_inputComponent.moveInput.z) != 0f;

            bool isJoystickMoving = _inputComponent.joystick.Horizontal != 0 || _inputComponent.joystick.Vertical != 0;
        
            isMoving = isMovingHorizontal || isMovingVertical || isJoystickMoving;
        }

        #endregion
    }
}
