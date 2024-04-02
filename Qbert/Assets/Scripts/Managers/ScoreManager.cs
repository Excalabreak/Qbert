using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [manages score]
 */

public class ScoreManager : Singleton<ScoreManager>
{
    private int _currentScore = 0;
    [SerializeField] private int[] _extraLivesAt;

    /// <summary>
    /// resets score
    /// </summary>
    public void ResetScore()
    {
        _currentScore = 0;
        UIManager.Instance.UpdateGameUI();
    }

    /// <summary>
    /// adds to score and checks if player gets an extra life
    /// </summary>
    /// <param name="score">how many points is added to score</param>
    public void AddScore(int score)
    {
        int temp = _currentScore;
        _currentScore += score;

        foreach (int scoreCheck in _extraLivesAt)
        {
            if (temp < scoreCheck && _currentScore >= scoreCheck)
            {
                LiveMananger.Instance.AddLives(1);
            }
        }
        UIManager.Instance.UpdateGameUI();
    }

    /// <summary>
    /// property to get current score
    /// </summary>
    public int currentScore
    {
        get { return _currentScore; }
    }
}
