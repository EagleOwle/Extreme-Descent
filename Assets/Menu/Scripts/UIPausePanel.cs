using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPausePanel : Menu, IMenuEvent
{
    [SerializeField] private Button returnButton;
    [SerializeField] private Button preferenceButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private UIPreferencePanel uiPreferencePanel;
    [SerializeField] private UIMenuExit uiMenuExit;

    public override event Action eventHide;
    public event Action<IMenuEvent> eventShow;
    public event Action<PointerType> eventOnPointer;

    public void Initialise()
    {
        returnButton.onClick.AddListener(OnButtonReturn);
        preferenceButton.onClick.AddListener(OnButtonPreference);
        exitButton.onClick.AddListener(OnButtonExit);

        uiMenuExit.Initialise();
        uiMenuExit.eventHide += OnEventHideChildMenu;

        uiPreferencePanel.Initialise();
        uiPreferencePanel.eventHide += OnEventHideChildMenu;

        foreach (var item in GetComponentsInChildren<UIButton>())
        {
            item.eventPointer += OnPointer;
        }

        uiPreferencePanel.gameObject.SetActive(false);
        uiMenuExit.gameObject.SetActive(false);
    }

    private void OnEventHideChildMenu()
    {
        UnlockCursor();
    }

    private void OnPointer(PointerType value)
    {
        eventOnPointer?.Invoke(value);
    }

    private void OnButtonReturn()
    {
        eventHide?.Invoke();
        base.Hide();
    }

    public override void Show()
    {
        eventShow?.Invoke(this);
        base.Show();
       
    }

    private void OnButtonPreference()
    {
        uiPreferencePanel.Show();
    }

    private void OnButtonExit()
    {
        uiMenuExit.Show();
    }
}
