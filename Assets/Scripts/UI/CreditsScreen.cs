using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScreen : Menu
{
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private Image _background;

    private void OnEnable()
    {
        _mainMenuButton.onClick.AddListener(BackToMainMenu);
    }

    private void OnDisable()
    {
        _mainMenuButton.onClick.RemoveListener(BackToMainMenu);
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        _background.GetComponent<CanvasGroup>().alpha = 1;
        _mainMenuButton.interactable = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _background.GetComponent<CanvasGroup>().alpha = 0;
        _mainMenuButton.interactable = false;
    }

    private void BackToMainMenu()
    {
        Time.timeScale = 0;
        _mainMenu.Open();
        Close();
    }
}