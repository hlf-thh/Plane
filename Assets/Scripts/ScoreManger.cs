using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text overText;
    private GameObject player;
    private int score = 0;

    void Awake()
    {
        // 确保只有一个 ScoreManager 实例
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // 初始化分数显示
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        // 增加分数并更新显示
        score += points;
        UpdateScoreText();
    }

    public void DelScore(int points)
    {
        // 增加分数并更新显示
        score -= points;
        UpdateScoreText();
        if(score < 0)
        {
            GameOver();
        }
    }

    private void UpdateScoreText()
    {
        // 更新屏幕上的分数显示
        scoreText.text = "Score: " + score;
    }

    private void GameOver()
    {
        player = GameObject.Find("Player");
        overText.gameObject.SetActive(true);
        Destroy(player);
        Time.timeScale = 0;
    }

}

