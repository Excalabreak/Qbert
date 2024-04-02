using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [manages player lives]
 */

public class LiveMananger : Singleton<LiveMananger>
{
    [SerializeField] private int _startingLives = 3;
    private int _currentLives;

    [SerializeField] private GameObject _qbertPrefab;
    private GameManager _gameManager;

    /// <summary>
    /// gets game manager
    /// </summary>
    private void OnEnable()
    {
        _gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
    }

    /// <summary>
    /// sets current lives to starting lives
    /// </summary>
    public void ResetLives()
    {
        _currentLives = _startingLives;
        UIManager.Instance.UpdateGameUI();
    }

    /// <summary>
    /// adds lives to the current lives
    /// </summary>
    /// <param name="numOfLives"></param>
    public void AddLives(int numOfLives)
    {
        _currentLives += numOfLives;
        UIManager.Instance.UpdateGameUI();
    }

    /// <summary>
    /// when player dies, 
    /// </summary>
    public void OnDeath()
    {
        _currentLives--;
        if (_currentLives <= 0)
        {
            _gameManager.OnGameOver();
        }
        else
        {
            //respawn
            EnemyManager.Instance.StopSpawningEnemies();
            EnemyManager.Instance.RemoveAllEnemies();
            UIManager.Instance.UpdateGameUI();
            SpawnQbert();
            EnemyManager.Instance.StartSpawningEnemies();
        }
    }

    /// <summary>
    /// instantiates a new qbert
    /// </summary>
    public void SpawnQbert()
    {
        Instantiate(_qbertPrefab);
    }

    /// <summary>
    /// property to get current lives
    /// </summary>
    public int currentLives
    {
        get { return _currentLives; }
    }
}
