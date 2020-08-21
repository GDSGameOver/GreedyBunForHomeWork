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
    private PlayerMover _playerMover;
    private int _pickedUpCoins;

    public event UnityAction GameOver;
    public event UnityAction<int> CoinsChanged;

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
        CoinsChanged?.Invoke(_pickedUpCoins);
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
        CoinsChanged?.Invoke(_pickedUpCoins);
    }

    public void GameOverScreenOpen()
    {
        GameOver?.Invoke();
    }
}
