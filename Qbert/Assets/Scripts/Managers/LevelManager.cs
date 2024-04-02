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

    public void NextLevel()
    {
        _currentLevel++;
        if (_currentLevel >= _numOfLevel)
        {
            //win
        }
        else
        {
            //reset map
            //start next level
            UIManager.Instance.UpdateGameUI();
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
