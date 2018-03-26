using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{

    public GameObject zigzgPanel;
    public GameObject tapText;
    public GameObject gameoverPanel;

    public TextMeshProUGUI goCurScoreText;
    public TextMeshProUGUI goBestScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    void Start()
    {
        bestScoreText.text = "Best Score: "+PlayerPrefs.GetInt("BestScore").ToString();
    }
    public void GameStart()
    {
        tapText.SetActive(false);
        zigzgPanel.GetComponent<Animator>().Play("StartPanelUp");
        scoreText.gameObject.SetActive(true);
    }


    public void GameOver()
    {
        scoreText.gameObject.SetActive(false);
        gameoverPanel.SetActive(true);
        goCurScoreText.text = ScoreManager.Instance.Score.ToString();
        goBestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }


    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }


}
