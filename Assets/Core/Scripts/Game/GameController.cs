using System;
using UnityEngine;

public interface IGameState
{
    event Action<bool> eventPauseGame; 
    event Action eventEndGame; 
}

public class GameController : MonoBehaviour, IGameState
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private Bike bike;
    [SerializeField] private SmoothFollow smoothFollow;
    [SerializeField] private UIGameMenuManager uiGameMenuManager;

    public bool dbPause;
    public event Action eventEndGame;
    public event Action<bool> eventPauseGame;

    private void Start()
    {
        uiGameMenuManager.Initialise();
        inputHandler.Initialise(this as IGameState);
        bike.eventIsDead += OnEventBallIsDead;
        bike.Initialise(this as IGameState);
        smoothFollow.Initialise(this as IGameState, bike.transform);
    }

    private void OnEventBallIsDead()
    {
        smoothFollow.ClearTarget();
        uiGameMenuManager.ShowDeadMenu();
    }

    private void PauseGame()
    {
        dbPause = true;
        uiGameMenuManager.eventHidePauseMenu += OnEventHidePauseMenu;
        uiGameMenuManager.ShowPauseMenu();
        eventPauseGame?.Invoke(true);
    }

    private void OnEventHidePauseMenu()
    {
        dbPause = false;
        eventPauseGame?.Invoke(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
}
