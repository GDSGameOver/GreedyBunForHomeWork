using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class CoinCollisionHandler : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _coinAudioPickupSound;
    private ParticleSystem _sparkle;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _coinAudioPickupSound = GetComponent<AudioSource>();
        _sparkle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player platform))
        {
            _animator.SetTrigger("Pickup");
            _coinAudioPickupSound.Play();
            _sparkle.Play();
        }

        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            transform.position += new Vector3(0, 2, 0);
        }
    }
}
