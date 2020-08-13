using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    public event UnityAction GameOverReached;
    public event UnityAction<int> NumberOfPickedUpCoinsChanged;

    private PlayerMover _playerMover;
    private int _pickedUpCoins;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void ResetPlayer()
    {
        _animator.SetTrigger("Idle");
        _pickedUpCoins = 0;
        NumberOfPickedUpCoinsChanged?.Invoke(_pickedUpCoins);
        _playerMover.ResetPlayer();
    }

    public void Die()
    {
        _animator.SetTrigger("Die");
        _audioSource.Play();
        _playerMover.ConvulsionsAfterDeath();
    }

    public void PickUpCoin()
    {
        _pickedUpCoins++;
        _animator.SetTrigger("CoinPickup");
        Debug.Log("Количество подобранных монет - " + _pickedUpCoins);
        NumberOfPickedUpCoinsChanged?.Invoke(_pickedUpCoins);
    }

    public void GameOverScreenOpen()
    {
        GameOverReached?.Invoke();
    }
}
