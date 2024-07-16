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
        // ȷ��ֻ��һ�� ScoreManager ʵ��
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // ��ʼ��������ʾ
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        // ���ӷ�����������ʾ
        score += points;
        UpdateScoreText();
    }

    public void DelScore(int points)
    {
        // ���ӷ�����������ʾ
        score -= points;
        UpdateScoreText();
        if(score < 0)
        {
            GameOver();
        }
    }

    private void UpdateScoreText()
    {
        // ������Ļ�ϵķ�����ʾ
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

