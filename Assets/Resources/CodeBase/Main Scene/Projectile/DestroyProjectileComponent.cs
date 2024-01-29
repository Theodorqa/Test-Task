using UnityEngine;

namespace Resources.CodeBase.Main_Scene.Projectile
{
    public class DestroyProjectileComponent : MonoBehaviour
    {
        #region Mono

        private void Start()
        {
            Destroy(gameObject, 5f); // Уничтожаем объект через 5 секунд после его появления
        }

        private void OnCollisionEnter(Collision other) // При столкновении тоже уничтожаем
        {
            Destroy(gameObject);
        }

        #endregion
    }
}