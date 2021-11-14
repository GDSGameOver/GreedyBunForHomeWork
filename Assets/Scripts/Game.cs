using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private MainCamera _camera;
    [SerializeField] private GameOverMenu _gameOverMenu;
    [SerializeField] private LevelGenerator _levelGenerator;
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
        _levelGenerator.Reset();
        _player.Reset();
        _camera.transform.position = _camera.StartPosition;
        _gameOverMenu.Open();
    }
}
