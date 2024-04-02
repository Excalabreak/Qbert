using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private int _score = 0;
    [SerializeField] private int[] _extraLivesAt;

    /// <summary>
    /// resets score
    /// </summary>
    public void ResetScore()
    {
        _score = 0;
    }

    /// <summary>
    /// adds to score and checks if player gets an extra life
    /// </summary>
    /// <param name="score">how many points is added to score</param>
    public void AddScore(int score)
    {
        int temp = _score;
        _score += score;

        foreach (int scoreCheck in _extraLivesAt)
        {
            if (temp < scoreCheck && _score >= scoreCheck)
            {
                LiveMananger.Instance.AddLives(1);
            }
        }
    }
}
