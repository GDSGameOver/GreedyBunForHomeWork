using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CameraMovement _playerTracking;
    [SerializeField] private PlatformGenerator _platformGenerator;
    [SerializeField] private CoinGenerator _coinGenerator;
    [SerializeField] private EnemyGenerator _enemyGenerator;

    public void StartGame()
    {
        Time.timeScale = 1;
        _player.ResetPlayer();
        _playerTracking.ResetCamera();
        _coinGenerator.ResetPool();
        _enemyGenerator.ResetPool();
        _platformGenerator.ResetPool();
        _platformGenerator.ActivateStartPlatform();
    }
}
