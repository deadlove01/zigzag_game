using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{

    public int Score;
    void Start()
    {
        Score = 0;
        PlayerPrefs.SetInt("Score", Score);
    }
    public void StartScore()
    {
        InvokeRepeating("IncreaseScore", 5, 2.5f);
    }


    public void StopScore()
    {
        CancelInvoke("IncreaseScore");
        PlayerPrefs.SetInt("Score", Score);
        var bestScore = PlayerPrefs.GetInt("BestScore");
        if (bestScore < Score)
        {
            PlayerPrefs.SetInt("BestScore", Score);
        }
    }


    void IncreaseScore()
    {
        Score++;
        UIManager.Instance.UpdateScore(Score);
    }

    public void AddMoreScore(int point)
    {
        Score += point;
        UIManager.Instance.UpdateScore(Score);
    }
}
