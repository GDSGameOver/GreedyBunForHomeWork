using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickedUpCoinsDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _pickedUpCoins;

    private void OnEnable()
    {
        _player.NumberOfPickedUpCoinsChanged += OnNumberOfPickedUpCoinsChanged;
    }

    private void OnDisable()
    {
        _player.NumberOfPickedUpCoinsChanged -= OnNumberOfPickedUpCoinsChanged;
    }

    private void OnNumberOfPickedUpCoinsChanged(int pickedUpCoins)
    {
        _pickedUpCoins.text = pickedUpCoins.ToString();
    }
}
