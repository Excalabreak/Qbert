using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [Handles win screen state]
 */

public class WinState : MonoBehaviour, IGameState
{
    private GameManager _gameManager;

    public void Handle(GameManager gameManager)
    {
        if (!_gameManager)
        {
            _gameManager = gameManager;
        }
        UIManager.Instance.ShowWinUI();
        EnemyManager.Instance.StopSpawningEnemies();
        EnemyManager.Instance.RemoveAllEnemies();
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        MapManager.Instance.DestoyMap();
    }
}
