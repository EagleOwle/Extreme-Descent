using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIDeadPanel : Menu, IMenuEvent
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private UIMenuExit uiMenuExit;

    public event Action<IMenuEvent> eventShow;
    public event Action<PointerType> eventOnPointer;

    public void Initialise()
    {
        uiMenuExit.Initialise();
        uiMenuExit.eventHide += OnEventHideChildMenu;
        restartButton.onClick.AddListener(OnButtonRestart);
        exitButton.onClick.AddListener(OnButtonExit);
    }

    public override void Show()
    {
        base.Show();
        eventShow?.Invoke(this);
    }

    private void OnEventHideChildMenu()
    {
        UnlockCursor();
    }

    private void OnButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnButtonExit()
    {
        uiMenuExit.Show();
    }

}
