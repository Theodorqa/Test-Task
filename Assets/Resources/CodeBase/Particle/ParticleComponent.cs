using UnityEngine;

namespace Resources.CodeBase.Particle
{
    public class ParticleComponent : MonoBehaviour
    {
        private ParticleSystem _particleSystem;

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

        private void ReactionToShoot()
        {
            _particleSystem.Play();
        }
    }
}