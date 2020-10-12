using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Movement _camera;
    [SerializeField] private GameOverMenu _gameOverMenu;
    [SerializeField] private PlayerCollisionHandler _endGameTrigger;
    private Spawner _spawners  = new Spawner();

    private void OnEnable()
    {
        _spawners = FindObjectOfType<Spawner>();
        _endGameTrigger.GameEnded += Reset;
    }

    private void OnDisable()
    {
        _endGameTrigger.GameEnded -= Reset;
    }

    private void Reset()
    {
        _player.Reset();
        _camera.Reset();
        _gameOverMenu.Open();
        _spawners.Reset();
    }
}
