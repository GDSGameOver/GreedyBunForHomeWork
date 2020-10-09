using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private PlatformSpawner _platformSpawner;
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Player _player;
    [SerializeField] private Movement _camera;
    [SerializeField] private GameOverMenu _gameOverMenu;
    [SerializeField] private PlayerCollisionHandler _endGameTrigger;

    private void OnEnable()
    {
        _endGameTrigger.GameEnded += Reset;
    }

    private void OnDisable()
    {
        _endGameTrigger.GameEnded -= Reset;
    }

    private void Reset()
    {
        _player.Reset();
        _camera.MoveToStartPosition();
        _coinSpawner.Reset();
        _enemySpawner.Reset();
        _platformSpawner.Reset();
        _gameOverMenu.Open();
    }
}
