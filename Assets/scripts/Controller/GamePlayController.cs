using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GamePlayController : MonoBehaviour {
    public static GamePlayController instance;
    [SerializeField]
    private Button instructionButton; // cần .gameObject

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;

    [SerializeField]
    private GameObject gameOverPanel, pausePanel; // là gameObject rồi

    void Awake()
    {
        Time.timeScale = 0; // 0 : đứng im màn hình\
        _makeInstance();
    }

    void _makeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void _instructionButton()
    {
        Time.timeScale = 1; // 1: game bắt đầu
        instructionButton.gameObject.SetActive(false);
    }

    public void _setScore(int score)
    {
        scoreText.text = "" + score;
    }
    public void _showPanelDied(int score)
    {
        gameOverPanel.SetActive(true);
        endScoreText.text = "" + score;

        if (score > GameMangerController.instance._getHighScore())
        {
            GameMangerController.instance._setHighScore(score);
        }

        bestScoreText.text = "" + GameMangerController.instance._getHighScore();
    }

    public void _menuButton()
    {
        SceneManager.LoadScene("main");
    }

    public void _restartButton()
    {
        SceneManager.LoadScene("game");
    }

    public void _pauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void _resumButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

}
