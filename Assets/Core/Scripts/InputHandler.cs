using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<InputHandler>();
            }

            return instance;
        }
    }
    private static InputHandler instance;

    [SerializeField] private UIInputPanel uIInputPanel;

    public float MoveDirection => moveDirection;
    private float moveDirection;

    public float UpDirection => upDirection;
    private float upDirection;

    private IGameState gameState;

    public void Initialise(IGameState gameState)
    {
        this.gameState = gameState;
        this.gameState.eventEndGame += GameState_eventEndGame;
        this.gameState.eventPauseGame += GameState_eventPauseGame;
    }

    private void Update()
    {
        InputListen();
    }

    private void InputListen()
    {
        moveDirection = uIInputPanel.ButtonValue.x;
        upDirection = -uIInputPanel.ButtonValue.y;
    }

    private void GameState_eventPauseGame(bool value)
    {
        this.enabled = !value;
    }

    private void GameState_eventEndGame()
    {
        throw new NotImplementedException();
    }

    private void OnDestroy()
    {
        this.gameState.eventEndGame -= GameState_eventEndGame;
        this.gameState.eventPauseGame -= GameState_eventPauseGame;
    }


}
