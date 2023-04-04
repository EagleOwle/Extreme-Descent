using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{
    public event Action eventIsDead;
    [SerializeField] private BikeMotor bikeMotor;

    private IGameState gameState;
    public void Initialise(IGameState gameState)
    {
        this.gameState = gameState;
        this.gameState.eventEndGame += GameState_eventEndGame;
        this.gameState.eventPauseGame += GameState_eventPauseGame;
    }

    private void GameState_eventPauseGame(bool value)
    {
        if (value == true)
        {
            bikeMotor.Sleep();
        }
        else
        {
            bikeMotor.WakeUp();
        }
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
