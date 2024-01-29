using System;
using System.Collections;
using UnityEngine;

namespace Resources.CodeBase.Main_Scene.Player
{
    public class ShootComponent : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint; // Точка выстрела
        [SerializeField] private GameObject _projectilePrefab; // Префаб пули

        public bool isShooting = false; // флажок для анимации
        private bool _canShoot = true; // флажок для задержки выстрела

        public static event Action OnShoot; // Событие, то что произошел выстрел

        #region User Methods

        public void Shoot() // Стрельба
        {
            if (_canShoot)
            {
                isShooting = true; // Для вкл. анимации
            
                OnShoot?.Invoke(); // Вызов события, что произошел выстрел
                GameObject projectile = Instantiate(_projectilePrefab, _shootPoint.position, _shootPoint.rotation); // Создание объекта пули

                StartCoroutine(ShootRecoil()); // Задержка выстрела

            
            }
        }

        private IEnumerator ShootRecoil() // Перезарядка
        {
            _canShoot = false;
            yield return new WaitForSeconds(1f);
            isShooting = false; // для выключения анимации
            _canShoot = true;
        }

        #endregion
    }
}
