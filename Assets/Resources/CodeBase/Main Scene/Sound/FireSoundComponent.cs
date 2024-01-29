using Resources.CodeBase.Main_Scene.Player;
using UnityEngine;

namespace Resources.CodeBase.Main_Scene.Sound
{
    public class FireSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioClip; // Звук, который будет проигрываться
        private AudioSource _audioSource;

        #region Mono

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            ShootComponent.OnShoot += PlayShootSound; // подписываемся на событие выстрела
        }

        private void OnDisable()
        {
            ShootComponent.OnShoot -= PlayShootSound;
        }

        #endregion

        #region User Methods

        private void PlayShootSound()  // при выстреле произойдет звук
        {
            _audioSource.PlayOneShot(_audioClip);
        }

        #endregion
    }
}
