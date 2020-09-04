using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameOverMenu : Menu
{
    [SerializeField] private PlatformSpawner _platformSpawner;
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Player _player;
    [SerializeField] private CameraMovement  _camera;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Image _background;

    public event UnityAction GameOverScreenOpen;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartGame);
        _mainMenuButton.onClick.AddListener(BackToMainMenu);
        _exitButton.onClick.AddListener(ExitGame);
        _player.GameOver += Open;
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartGame);
        _mainMenuButton.onClick.RemoveListener(BackToMainMenu);
        _exitButton.onClick.RemoveListener(ExitGame);
        _player.GameOver -= Open;
    }

    private void ExitGame()
    {
        Application.Quit();
    }
    
    private void RestartGame()
    {
        Time.timeScale = 1;
        Close();
    }

    public override void Open()
    {
        Time.timeScale = 0;
        CanvasGroup.alpha = 1;
        _background.GetComponent<CanvasGroup>().alpha = 1;
        _restartButton.interactable = true;
        _mainMenuButton.interactable = true;
        _exitButton.interactable = true;
        _player.ResetPlayer();
        _camera.MoveToStartPosition();
        _coinSpawner.ResetPool();
        _enemySpawner.ResetPool();
        _platformSpawner.ResetPool();
        _platformSpawner.ActivateStartPlatform();
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _background.GetComponent<CanvasGroup>().alpha = 0;
        _restartButton.interactable = false;
        _mainMenuButton.interactable = false;
        _exitButton.interactable = false;
    }

    private void BackToMainMenu()
    {
        Time.timeScale = 0;
        _mainMenu.Open();
        Close();
    }
}
