using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [Manages all enemies]
 */

public class EnemyManager : Singleton<EnemyManager>
{
    private List<GameObject> _currentEnemies = new List<GameObject>();
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private int[] _indexLimit;
    [SerializeField] private float[] _spawnSpeed;
    [SerializeField] private float _freezeTime = 5f;

    private bool _spawning = false;
    private int _currentLevel = 0;
    private bool _snakeIn = false;
    private bool _greenBallIn = false;

    /// <summary>
    /// here for testing, take out
    /// </summary>
    private void Start()
    {
        //StartSpawningEnemies();
    }

    /// <summary>
    /// starts spawning enemy
    /// </summary>
    public void StartSpawningEnemies()
    {
        _spawning = true;
        StartCoroutine(Spawn());
    }

    /// <summary>
    /// stop spawning enemies
    /// </summary>
    public void StopSpawningEnemies()
    {
        _spawning = false;
        StopCoroutine(Spawn());
    }

    /// <summary>
    /// Removes all enemy from scene
    /// </summary>
    public void RemoveAllEnemies()
    {
        foreach (GameObject enemy in _currentEnemies)
        {
            Destroy(enemy);
        }
        _snakeIn = false;
        _greenBallIn = false;
        _currentEnemies.Clear();
    }

    /// <summary>
    /// Removes an enemy from list and from scene
    /// </summary>
    /// <param name="enemy">enemy to remove</param>
    public void RemoveEnemy(GameObject enemy)
    {
        if (enemy.GetComponent<SnakeMoveScript>() != null)
        {
            _snakeIn = false;
        }
        else if (enemy.tag == "GreenBall")
        {
            _greenBallIn = false;
        }

        _currentEnemies.Remove(enemy);
        Destroy(enemy);
    }

    /// <summary>
    /// freezes all enemies 
    /// </summary>
    public void FreezeAllEnemies()
    {
        StartCoroutine(Freeze());
    }

    /// <summary>
    /// freezes all enemies for _freezeTime seconds
    /// </summary>
    /// <returns></returns>
    private IEnumerator Freeze()
    {
        foreach (GameObject enemy in _currentEnemies)
        {
            enemy.GetComponent<BaseHopScript>().frozen = true;
        }
        StopSpawningEnemies();

        //TODO: make player invincible

        yield return new WaitForSeconds(_freezeTime);

        StartSpawningEnemies();
        foreach (GameObject enemy in _currentEnemies)
        {
            enemy.GetComponent<BaseHopScript>().frozen = false;
        }
    }

    /// <summary>
    /// spawns enemies until _spawning is false
    /// </summary>
    /// <returns></returns>
    private IEnumerator Spawn()
    {
        while (_spawning)
        {
            yield return new WaitForSeconds(_spawnSpeed[_currentLevel]);

            int spawnIndex = Random.Range(0, _indexLimit[_currentLevel]+1);

            if (spawnIndex == 1)
            {
                if (_snakeIn)
                {
                    spawnIndex = 0;
                }
                else
                {
                    _snakeIn = true;
                }
            }
            else if (spawnIndex == 2)
            {
                if (_greenBallIn)
                {
                    spawnIndex = 0;
                }
                else
                {
                    _greenBallIn = true;
                }
            }

            GameObject enemy = Instantiate(_enemyPrefabs[spawnIndex]);
            _currentEnemies.Add(enemy);
        }
    }
}
