using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationComponent : MonoBehaviour
{
    [SerializeField] private MoveComponent _moveComponent; // Для проверки скорости объекта
    [SerializeField] private ShootComponent _shootComponent; // Для проверки стрельбы объекта
    
    private Animator _animator;
    private static readonly int Run = Animator.StringToHash("isRunning");
    private static readonly int Shoot = Animator.StringToHash("isShooting");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetAnimation();
    }

    private void SetAnimation() // Ставим анимацию в зависимости обстоятельств(если isMoving == true, играем анимацию Run)
    {
        _animator.SetBool(Run, _moveComponent.isMoving);
        _animator.SetBool(Shoot, _shootComponent.isShooting);
    }
}
