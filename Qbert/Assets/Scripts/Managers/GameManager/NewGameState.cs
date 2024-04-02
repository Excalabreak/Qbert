using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * []
 */

public class NewGameState : MonoBehaviour, IGameState
{
    private GameManager _gameManager;

    public void Handle(GameManager gameManager)
    {
        if (!_gameManager)
        {
            _gameManager = gameManager;
        }

        UIManager.Instance.ShowGameUI();
        LiveMananger.Instance.ResetLives();
        ScoreManager.Instance.ResetScore();
        LevelManager.Instance.ResetLevel();
        //create new map
        //create new qbert
        //start enemy spawn
    }
}
