using UnityEngine;

namespace Resources.CodeBase.Main_Scene.Player
{
    public class CameraFollowComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target; // Цель, за которой следует камера
        [SerializeField] private Vector3 _offset; // Смещение

        #region Mono

        private void Update()
        {
            transform.position = _target.position + _offset;
        }

        #endregion
    }
}