using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class CoinCollisionHandler : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _pickupSound;
    private ParticleSystem _sparkle;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _pickupSound = GetComponent<AudioSource>();
        _sparkle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _animator.SetTrigger("Pickup");
            _pickupSound.Play();
            _sparkle.Play();
        }
    }
}