using Resources.CodeBase.Main_Scene.Player;
using UnityEngine;

namespace Resources.CodeBase.Main_Scene.Particle
{
    public class ParticleComponent : MonoBehaviour
    {
        private ParticleSystem _particleSystem;

        #region  Mono

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        private void OnEnable()
        {
            ShootComponent.OnShoot += ReactionToShoot;
        }

        private void OnDisable()
        {
            ShootComponent.OnShoot -= ReactionToShoot;
        }

        #endregion

        #region User Methods

        private void ReactionToShoot()
        {
            _particleSystem.Play();
        }

        #endregion
    }
}