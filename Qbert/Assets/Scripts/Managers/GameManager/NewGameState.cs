using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [Handles starting a new game]
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
        MapManager.Instance.MakeMap();
        MapManager.Instance.SetMapCubesObjective();
        LiveMananger.Instance.SpawnQbert();
        EnemyManager.Instance.StartSpawningEnemies();
    }
}
