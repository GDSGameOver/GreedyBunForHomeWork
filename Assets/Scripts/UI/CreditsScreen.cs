using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CreditsScreen : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;

    public event UnityAction MainMenuButtonClickReached;

    private void OnEnable()
    {
        _mainMenuButton.onClick.AddListener(MainMenuButtonClick);
    }

    private void OnDisable()
    {
        _mainMenuButton.onClick.RemoveListener(MainMenuButtonClick);
    }

   

    private void MainMenuButtonClick()
    {
        MainMenuButtonClickReached?.Invoke();
    }
}
