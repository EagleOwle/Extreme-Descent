using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] private float smooth = 1;
    [SerializeField] private Vector3 offset;

    private Transform target;
    private float positionZ;

    private IGameState gameState;

    public void Initialise(IGameState gameState, Transform target)
    {
        this.gameState = gameState;
        this.gameState.eventEndGame += GameState_eventEndGame;
        this.gameState.eventPauseGame += GameState_eventPauseGame;
        SetTarget(target);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void ClearTarget()
    {
        this.target = null;
    }

    private void Start()
    {
        positionZ = transform.position.z;
    }

    private void LateUpdate()
    {
        if(target == null)
        {
            GameState_eventPauseGame(true);
            return;
        }

        transform.position = Vector3.Lerp(transform.position, target.position + offset, smooth * Time.deltaTime);
    }

    private void GameState_eventPauseGame(bool value)
    {
        if (value == true)
        {
            enabled = false;
        }
        else
        {
            enabled = true;
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
