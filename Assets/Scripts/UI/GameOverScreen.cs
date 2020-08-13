using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] protected Button _restartButton;
    [SerializeField] protected Button _mainMenuButton;
    [SerializeField] protected Button _exitButton;

    public UnityAction RestartButtonClickReached;
    public UnityAction MainMenuButtonClickReached;
    public UnityAction ExitButtonClickReached;


    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartButtonClick);
        _mainMenuButton.onClick.AddListener(MainMenuButtonClick);
        _exitButton.onClick.AddListener(ExitButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartButtonClick);
        _mainMenuButton.onClick.RemoveListener(MainMenuButtonClick);
        _exitButton.onClick.RemoveListener(ExitButtonClick);
    }


    private void RestartButtonClick()
    {
        RestartButtonClickReached?.Invoke();
    }

    private void MainMenuButtonClick()
    {
        MainMenuButtonClickReached?.Invoke();
    }

    private void ExitButtonClick()
    {
        ExitButtonClickReached?.Invoke();
    }
}
