using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Resources.CodeBase.Projectile
{
    public class DestroyProjectileComponent : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 5f); // Уничтожаем объект через 5 секунд после его появления
        }

        private void OnCollisionEnter(Collision other) // При столкновении тоже уничтожаем
        {
            Destroy(gameObject);
        }
    }
}