using Resources.CodeBase.Main_Scene.Services;
using UnityEngine;

namespace Resources.CodeBase.Main_Scene.Player
{
    public class InputComponent : MonoBehaviour, IInputService // Компонент, для распознования ввода пользователя
    {
        public Joystick joystick;
        public Vector3 moveInput { get; set; } // Считаваем ввод пользователя для движения
        
        // Тип ввода (пользователь сам выбирает)
        public enum ControlType {PC, Android}
        public ControlType controlType;

        #region Mono

        private void Update()
        {
            if(controlType == ControlType.PC)
                moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); // Вектор движения
            else if(controlType == ControlType.Android)
                moveInput = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
        }

        #endregion
    }
}
