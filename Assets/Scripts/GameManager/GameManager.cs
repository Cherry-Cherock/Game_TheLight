using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMono<GameManager>
{
    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSED,
        INVENTORY,
        TUTORIAL,
        MAP,
        GAME_OVER,
    }
    
    public enum GameLevel
    {
        TEST,
        LEVEL1
    }
    
    #region GAME MANAGER VARIABLES
    public  EventGameState                 OnGameStateChanged;
    private List<AsyncOperation>        loadOperations;
    public  GameState                   currentGameState = GameState.PREGAME;
    private GameLevel                   currentLevelName = GameLevel.TEST;
    #endregion

    private void Update()
    {
        if (currentGameState == GameState.PREGAME)
        {
            return;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public GameState CurrentGameState
    {
        get => currentGameState;
        private set => currentGameState = value;
    }
    
    void UpdateState(GameState state)
    {
        GameState previousGameState = currentGameState;
        currentGameState = state;

        switch (CurrentGameState)
        {
            case GameState.PREGAME:
                Time.timeScale = 1.0f;
                break;

            case GameState.RUNNING:
                Time.timeScale      = 1.0f;
                AudioListener.pause = false;
                break;

            case GameState.PAUSED:
                Time.timeScale      = 0.0f;
                AudioListener.pause = true;
                break;

            case GameState.INVENTORY:
                Time.timeScale = 0.0f;
                break;

            case GameState.MAP:
                Time.timeScale = 0.0f;
                break;

            case GameState.TUTORIAL:
                Time.timeScale = 0.0f;
                break;

            case GameState.GAME_OVER:
                Time.timeScale = 1.0f;
                break;

            default:
                break;
        }

        OnGameStateChanged.Invoke(currentGameState, previousGameState);
    }
    
    public void TogglePause() =>
        UpdateState(currentGameState == GameState.RUNNING ? GameState.PAUSED : GameState.RUNNING);
    public void ToggleInventory() =>
        UpdateState(currentGameState == GameState.RUNNING ? GameState.INVENTORY : GameState.RUNNING);
    public void ToggleMap() =>
        UpdateState(currentGameState == GameState.RUNNING ? GameState.MAP : GameState.RUNNING);
    public void ToggleTutorial() =>
        UpdateState(currentGameState == GameState.RUNNING ? GameState.TUTORIAL : GameState.RUNNING);
    void HandleGameOver()
    {
        StartCoroutine(WaitForIt());
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2f);
        UpdateState(currentGameState == GameState.RUNNING ? GameState.GAME_OVER : GameState.RUNNING);
    }
    
    [Serializable]
    public class EventGameState : UnityEvent<GameState, GameState>
    {
    }
}
