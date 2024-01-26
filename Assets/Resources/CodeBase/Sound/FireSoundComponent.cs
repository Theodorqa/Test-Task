using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSoundComponent : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip; // Звук, который будет проигрываться
    private AudioSource _audioSource;

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

    private void PlayShootSound()  // при выстреле произойдет звук
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}
