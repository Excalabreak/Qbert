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
    private IGameState _titleState, _newGameState;

    private GameStateContext _gameStateContext;

    private void Start()
    {
        _gameStateContext = new GameStateContext(this);

        _titleState = gameObject.GetComponent<TitleState>();
        _newGameState = gameObject.GetComponent<NewGameState>();

        _gameStateContext.Transition(_titleState);
    }

    public void StartGame()
    {
        _gameStateContext.Transition(_newGameState);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
