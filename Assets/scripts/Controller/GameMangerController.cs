using UnityEngine;
using System.Collections;

public class GameMangerController : MonoBehaviour {
    public static GameMangerController instance;

    private const string HIGH_SCORE = "High Score";
    void Awake()
    {
        _makeSingleInstance();
        _isGameStartedForTheFirstTime();
    }

    void _isGameStartedForTheFirstTime()
    {
        if (PlayerPrefs.HasKey("_isGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt("_isGameStartedForTheFirstTime", 0);
        }
    }

    void _makeSingleInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void _setHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score); // lưu trữ điểm cao nhất
    }

    public int _getHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}
