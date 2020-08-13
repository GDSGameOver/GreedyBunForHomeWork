using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] protected Button _playButton;
    [SerializeField] protected Button _creditsButton;
    [SerializeField] protected Button _exitButton;

    public event UnityAction PlayButtonClickReached;
    public event UnityAction CreditsButtonClickReached;
    public event UnityAction ExitButtonClickReached;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(PlayButtonClick);
        _creditsButton.onClick.AddListener(CreditsButtonClick);
        _exitButton.onClick.AddListener(ExitButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(PlayButtonClick);
        _creditsButton.onClick.RemoveListener(CreditsButtonClick);
        _exitButton.onClick.RemoveListener(ExitButtonClick);
    }

    private void PlayButtonClick()
    {
        PlayButtonClickReached?.Invoke();
    }

    private void CreditsButtonClick()
    {
        CreditsButtonClickReached?.Invoke();
    }

    private void ExitButtonClick()
    {
        ExitButtonClickReached?.Invoke();
    }
}
