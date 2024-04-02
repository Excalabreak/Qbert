using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [Handles what the level is]
 */

public class LevelManager : Singleton<LevelManager>
{
    private int _currentLevel = 0;
    [SerializeField] private int _numOfLevel = 4;
    private GameManager _gameManager;

    /// <summary>
    /// gets game manager
    /// </summary>
    private void OnEnable()
    {
        _gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
    }

    /// <summary>
    /// sets up next level or calls to win state
    /// </summary>
    public void NextLevel()
    {
        _currentLevel++;
        if (_currentLevel >= _numOfLevel)
        {
            _gameManager.OnWin();
        }
        else
        {
            EnemyManager.Instance.StopSpawningEnemies();
            EnemyManager.Instance.RemoveAllEnemies();
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            MapManager.Instance.DestoyMap();

            MapManager.Instance.MakeMap();
            MapManager.Instance.SetMapCubesObjective();
            EnemyManager.Instance.StartSpawningEnemies();
            UIManager.Instance.UpdateGameUI();
            LiveMananger.Instance.SpawnQbert();
        }
    }

    public void ResetLevel()
    {
        _currentLevel = 0;
        UIManager.Instance.UpdateGameUI();
    }


    public int currentLevel
    {
        get { return _currentLevel; }
    }
}
