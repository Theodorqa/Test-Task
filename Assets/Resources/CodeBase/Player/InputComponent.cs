using Resources.CodeBase.Services;
using UnityEngine;

namespace Resources.CodeBase.Player
{
    public class InputComponent : MonoBehaviour, IInputService // Компонент, для распознования ввода пользователя
    {
        public Vector3 moveInput { get; set; } // Считаваем ввод пользователя для движения
        
        public enum ControlType {PC, Android} // Тип ввода (пользователь сам выбирает)
        public ControlType controlType;

        public Joystick joystick;
        private void Update()
        {
            if(controlType == ControlType.PC)
                moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); // Вектор движения
            else if(controlType == ControlType.Android)
                moveInput = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
        }
    }
}
