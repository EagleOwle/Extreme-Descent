using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIGameMenuManager : MonoBehaviour
{
    public event Action eventHidePauseMenu;

    [SerializeField] private UIPausePanel pausePanel;
    [SerializeField] private UIDeadPanel deadPanel;
    [SerializeField] private SoundControllerMenu soundController;

    public void Initialise()
    {
        pausePanel.Initialise();
        pausePanel.eventHide += OnEventHidePauseMenu;
        pausePanel.eventShow += OnEventShow;

        deadPanel.Initialise();
    }

    public void ShowPauseMenu()
    {
        pausePanel.Show();
    }

    public void ShowDeadMenu()
    {
        pausePanel.Hide();
        deadPanel.Show();
    }

    private void OnEventHidePauseMenu()
    {
        eventHidePauseMenu?.Invoke();
    }

    private void OnEventShow(IMenuEvent menu)
    {
        soundController.Initialise(menu); //TODO: сделать добавление в soundController всех эдементов меню единожды
    }

}
