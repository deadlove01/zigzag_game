using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int goldPoint = 3;
    //private bool isGameOver = false;


    void Start()
    {
        //isGameOver = false;
    }

    public void StartGame()
    {
        UIManager.Instance.GameStart();
        ScoreManager.Instance.StartScore();
    }


    public void EndGame()
    {
        //isGameOver = true;
        UIManager.Instance.GameOver();
        ScoreManager.Instance.StopScore();
    }

}
