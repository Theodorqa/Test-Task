using System;
using UnityEngine;

namespace Resources.CodeBase.Player
{
    public class CameraFollowComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target; // Цель, за которой следует камера
        [SerializeField] private Vector3 _offset; // Смещение

        private void Update()
        {
            transform.position = _target.position + _offset;
        }
    }
}