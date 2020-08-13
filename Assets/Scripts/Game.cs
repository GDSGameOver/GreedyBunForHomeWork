using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Platform _startPlatform;
    [SerializeField] private Player _player;
    [SerializeField] private PlatformGenerator _platformGenerator;
    [SerializeField] private CoinGenerator _coinGenerator;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private CreditsScreen _creditsScreen;

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.gameObject.SetActive(true);
        _gameOverScreen.gameObject.SetActive(false);
        _creditsScreen.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClickReached += OnPlayButtonClick;
        _startScreen.CreditsButtonClickReached += OnCreditsButtonClick;
        _startScreen.ExitButtonClickReached += OnExitButtonClick;
        _gameOverScreen.RestartButtonClickReached += OnRestartButtonClick;
        _gameOverScreen.MainMenuButtonClickReached += OnBackToMainMenuFromGameOverScreenButtonClick;
        _gameOverScreen.ExitButtonClickReached += OnExitButtonClick;
        _player.GameOverReached += OnGameOver;
        _creditsScreen.MainMenuButtonClickReached += OnBackToMainMenuFromCreditsButtonClick;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClickReached -= OnPlayButtonClick;
        _startScreen.CreditsButtonClickReached -= OnCreditsButtonClick;
        _startScreen.ExitButtonClickReached -= OnExitButtonClick;
        _gameOverScreen.RestartButtonClickReached -= OnRestartButtonClick;
        _gameOverScreen.MainMenuButtonClickReached -= OnBackToMainMenuFromGameOverScreenButtonClick;
        _gameOverScreen.ExitButtonClickReached -= OnExitButtonClick;
        _player.GameOverReached -= OnGameOver;
        _creditsScreen.MainMenuButtonClickReached -= OnBackToMainMenuFromCreditsButtonClick;
    }

    private void OnPlayButtonClick()
    {
        _startScreen.gameObject.SetActive(false);
        _startPlatform.gameObject.SetActive(true);
        _coinGenerator.ResetPool();
        _enemyGenerator.ResetPool();
        _platformGenerator.ResetPool();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.gameObject.SetActive(false);
        _coinGenerator.ResetPool();
        _enemyGenerator.ResetPool();
        _platformGenerator.ResetPool();
        _startPlatform.gameObject.SetActive(true);
        StartGame();
    }

    private void OnCreditsButtonClick()
    {
        _startScreen.gameObject.SetActive(false);
        _creditsScreen.gameObject.SetActive(true);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnBackToMainMenuFromCreditsButtonClick()
    {
        _creditsScreen.gameObject.SetActive(false);
        _startScreen.gameObject.SetActive(true);
    }

    private void OnBackToMainMenuFromGameOverScreenButtonClick()
    {
        _gameOverScreen.gameObject.SetActive(false);
        _startScreen.gameObject.SetActive(true);
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.ResetPlayer();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _startPlatform.gameObject.SetActive(false);
        _gameOverScreen.gameObject.SetActive(true);
    }
}
