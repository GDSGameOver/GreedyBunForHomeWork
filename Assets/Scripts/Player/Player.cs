using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    private PlayerMovement _movement;
    private Animator _animator;
    private AudioSource _audioSource;
    private Rigidbody2D _rigidbody2D;
    private int _pickedUpCoins;
    
    public event UnityAction GameOver;
    public event UnityAction<int> CoinPickedUp;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _movement = GetComponent<PlayerMovement>();
    }

    public void ResetPlayer()
    {
        _animator.SetTrigger("Idle");
        _pickedUpCoins = 0;
        _movement.MoveToStartPosition();
        CoinPickedUp?.Invoke(_pickedUpCoins);
    }

    public void Die()
    {
        _animator.SetTrigger("Die");
        _audioSource.Play();
        ConvulsionsAfterDeath();
    }

    public void PickUpCoin()
    {
        _pickedUpCoins++;
        _animator.SetTrigger("CoinPickup");
        CoinPickedUp?.Invoke(_pickedUpCoins);
    }

    public void GameOverScreenOpen()
    {
        GameOver?.Invoke();
    }

    public void ConvulsionsAfterDeath()
    {
        _rigidbody2D.velocity = new Vector2(0, 20);
        _rigidbody2D.AddForce(Vector2.up * 10, ForceMode2D.Force);
    }
}
