using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.InputSystem;

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
    
    public enum InteractionType
    {
        NONE,
        SHOP
    }
    
    public enum GameLevel
    {
        TEST,
        LEVEL1
    }
    
    #region GAME MANAGER VARIABLES
    public  EventGameState              OnGameStateChanged;
    private List<AsyncOperation>        loadOperations;
    public static  GameState            currentGameState = GameState.PREGAME;
    public static InteractionType       currentInteractionState = InteractionType.NONE;
    private GameLevel                   currentLevelName = GameLevel.TEST;
    private PlayerControl inputSystem;
    #endregion

    void Awake ()
    {
        inputSystem = InputManager.inputActions;
    }
	
    private void OnEnable()
    {
        inputSystem.Enable();
        inputSystem.Game.PausedGame.started += PauseCurrentGame;
        ShopInteraction.shop += PauseGame;
        InventoryInputHandler.usInfo += PauseGame;
        TogglePregame();
    }

    public void PauseCurrentGame(InputAction.CallbackContext context)
    {
        TogglePause();
        UIManager.Show<PauseUI>();
    }

    
    public void PauseGame()
    {
        TogglePause();
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
                Time.timeScale = 0.0f;
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
    
    public void TogglePause(){
         UpdateState(currentGameState == GameState.RUNNING ? GameState.PAUSED : GameState.RUNNING);
         Debug.Log(currentGameState);
    }
    


    public void TogglePregame()
    {
        UpdateState(GameState.PREGAME);
    }
    
       
    
    public void ToggleInventory() =>
        UpdateState(currentGameState == GameState.RUNNING ? GameState.INVENTORY : GameState.RUNNING);
    public void ToggleMap() =>
        UpdateState(currentGameState == GameState.RUNNING ? GameState.MAP : GameState.RUNNING);
    public void ToggleTutorial() =>
        UpdateState(currentGameState == GameState.RUNNING ? GameState.TUTORIAL : GameState.RUNNING);

    public static void HandleGameStart()
    {
        currentGameState = GameState.RUNNING;
        Time.timeScale      = 1.0f;
        AudioListener.pause = false;
    }
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
