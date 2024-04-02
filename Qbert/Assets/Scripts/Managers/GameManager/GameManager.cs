using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [Game manager that handles all of the game state]
 */

public class GameManager : MonoBehaviour
{
    private IGameState _titleState, _newGameState, _gameOverState, _winState;

    private GameStateContext _gameStateContext;

    private void Start()
    {
        _gameStateContext = new GameStateContext(this);

        _titleState = gameObject.GetComponent<TitleState>();
        _newGameState = gameObject.GetComponent<NewGameState>();
        _gameOverState = gameObject.GetComponent<GameOverState>();
        _winState = gameObject.GetComponent<WinState>();

        _gameStateContext.Transition(_titleState);
    }

    /// <summary>
    /// starts game
    /// </summary>
    public void StartGame()
    {
        _gameStateContext.Transition(_newGameState);
    }

    /// <summary>
    /// goes into game over state
    /// </summary>
    public void OnGameOver()
    {
        _gameStateContext.Transition(_gameOverState);
    }

    /// <summary>
    /// goes to win screen
    /// </summary>
    public void OnWin()
    {
        _gameStateContext.Transition(_winState);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
