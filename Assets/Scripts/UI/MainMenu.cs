using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private CreditsScreen _creditsMenu;
    [SerializeField] private Image _background;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(StartGame);
        _creditsButton.onClick.AddListener(OpenCreditsMenu);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(StartGame);
        _creditsButton.onClick.RemoveListener(OpenCreditsMenu);
        _exitButton.onClick.RemoveListener(ExitGame);
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        Close();
    }

    private void OpenCreditsMenu()
    {
        Close();
        _creditsMenu.Open();
    } 

    private void ExitGame()
    {
        Application.Quit();
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        _background.GetComponent<CanvasGroup>().alpha = 1;
        _creditsButton.interactable = true;
        _playButton.interactable = true;
        _exitButton.interactable = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _background.GetComponent<CanvasGroup>().alpha = 0;
        _creditsButton.interactable = false;
        _playButton.interactable = false;
        _exitButton.interactable = false;
    }
}
