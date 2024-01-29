using UnityEngine;
using Zenject;

namespace Resources.CodeBase.Main_Scene.Player
{
    [RequireComponent(typeof(Animator))]
    public class AnimationComponent : MonoBehaviour
    {
        [Inject] private MoveComponent _moveComponent; // Для проверки скорости объекта
        [Inject] private ShootComponent _shootComponent; // Для проверки стрельбы объекта

        private static readonly int Run = Animator.StringToHash("isRunning");
        private static readonly int Shoot = Animator.StringToHash("isShooting");

        private Animator _animator;

        #region Mono

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            SetAnimation();
        }

        #endregion

        #region User Methods

        private void SetAnimation() // Ставим анимацию в зависимости обстоятельств(если isMoving == true, играем анимацию Run)
        {
            _animator.SetBool(Run, _moveComponent.isMoving);
            _animator.SetBool(Shoot, _shootComponent.isShooting);
        }

        #endregion
    }
}
