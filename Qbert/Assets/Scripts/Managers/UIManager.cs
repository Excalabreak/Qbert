using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/01/2024]
 * [Handles the UI of the game]
 */

public class UIManager : Singleton<UIManager>
{
    //text
    [SerializeField] private TMP_Text _livesText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _targetText;
    [SerializeField] private TMP_Text _titleText;

    //buttons
    [SerializeField] private GameObject _playButton;
    [SerializeField] private TMP_Text _playText;
    [SerializeField] private GameObject _quitButton;
    [SerializeField] private RectTransform _quitButtonPos;

    /// <summary>
    /// hides all UI
    /// </summary>
    public void HideAllUI()
    {
        _livesText.enabled = false;
        _scoreText.enabled = false;
        _levelText.enabled = false;
        _titleText.enabled = false;
        _targetText.enabled = false;
        _playButton.SetActive(false);
        _quitButton.SetActive(false);
    }

    /// <summary>
    /// shows the title screen
    /// </summary>
    public void ShowTitleScreen()
    {
        HideAllUI();

        _titleText.enabled = true;
        _titleText.text = "Q*BERT";

        _playButton.SetActive(true);
        _playText.text = "Play";

        _quitButton.SetActive(true);
    }

    /// <summary>
    /// shows game ui
    /// </summary>
    public void ShowGameUI()
    {
        HideAllUI();
        _levelText.enabled = true;
        _scoreText.enabled = true;
        _livesText.enabled = true;
        _targetText.enabled = true;
    }

    /// <summary>
    /// shows game over screen
    /// </summary>
    public void ShowGameOverUI()
    {
        HideAllUI();

        _livesText.enabled = true;
        _levelText.enabled = true;
        _scoreText.enabled = true;

        _titleText.enabled = true;
        _titleText.text = "GAME OVER";

        _playButton.SetActive(true);
        _playText.text = "Replay";

        _quitButton.SetActive(true);
    }

    /// <summary>
    /// shows win screen
    /// </summary>
    public void ShowWinUI()
    {
        HideAllUI();

        _livesText.enabled = true;
        _levelText.enabled = true;
        _scoreText.enabled = true;

        _titleText.enabled = true;
        _titleText.text = "YOU WIN";

        _playButton.SetActive(true);
        _playText.text = "Replay";

        _quitButton.SetActive(true);
    }

    public void UpdateGameUI()
    {
        _livesText.text = "Lives: " + LiveMananger.Instance.currentLives;
        _scoreText.text = "Score: " + ScoreManager.Instance.currentScore;
        _levelText.text = "Level: " + LevelManager.Instance.currentLevel + 1;
    }
}
