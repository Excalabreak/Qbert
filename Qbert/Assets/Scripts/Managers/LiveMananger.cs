using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveMananger : Singleton<LiveMananger>
{
    [SerializeField] private int _startingLives = 3;
    private int _currentLives;

    /// <summary>
    /// sets current lives to starting lives
    /// </summary>
    public void ResetLives()
    {
        _currentLives = _startingLives;
    }

    /// <summary>
    /// adds lives to the current lives
    /// </summary>
    /// <param name="numOfLives"></param>
    public void AddLives(int numOfLives)
    {
        _currentLives += numOfLives;
    }

    /// <summary>
    /// when player dies, 
    /// </summary>
    public void OnDeath()
    {
        _currentLives--;
        if (_currentLives <= 0)
        {
            //trigger game over
        }
        else
        {
            //respawn
        }
    }
}
