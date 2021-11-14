using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;

    private Animator _animator;
    private AudioSource _audioSource;
    private Rigidbody2D _rigidbody;
    private int _pickedUpCoins;
    
    public event UnityAction<int> CoinPickedUp;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Reset()
    {
        _animator.SetTrigger("Idle");
        _pickedUpCoins = 0;
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
        CoinPickedUp?.Invoke(_pickedUpCoins);
    }

    public void Die()
    {
        _animator.SetTrigger("Die");
        _audioSource.Play();
    }

    public void PickUpCoin()
    {
        _pickedUpCoins++;
        _animator.SetTrigger("CoinPickup");
        CoinPickedUp?.Invoke(_pickedUpCoins);
    }
}
