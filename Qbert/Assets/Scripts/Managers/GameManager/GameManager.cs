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
    private IGameState _titleState, _playState, _deathState, _gameOverState, _winState;

    private GameStateContext _gameStateContext;

    private void Start()
    {
        _gameStateContext = new GameStateContext(this);

        _titleState = gameObject.GetComponent<TitleState>();
        _playState = gameObject.GetComponent<PlayState>();
        _deathState = gameObject.GetComponent<DeathState>();
        _gameOverState = gameObject.GetComponent<GameOverState>();
        _winState = gameObject.GetComponent<WinState>();
    }
}
