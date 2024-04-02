using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [Handles GameOver Screen]
 */

public class GameOverState : MonoBehaviour, IGameState
{
    private GameManager _gameManager;

    public void Handle(GameManager gameManager)
    {
        if (!_gameManager)
        {
            _gameManager = gameManager;
        }
        UIManager.Instance.ShowGameOverUI();
        EnemyManager.Instance.StopSpawningEnemies();
        EnemyManager.Instance.RemoveAllEnemies();
        MapManager.Instance.DestoyMap();
    }
}
