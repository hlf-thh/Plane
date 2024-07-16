using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BloodManger : MonoBehaviour
{
    public static BloodManger instance;
    public Text bloodText;
    public Text overText;
    private GameObject player;

    private int blood = 10;
    // Start is called before the first frame update
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
       
        // 初始化血量显示
        UpdateBloodText();
    }

    public void DelBlood(int points)
    {
        // 减少血量并更新显示
        blood -= points;
        UpdateBloodText();
        if(blood == 0)
        {
            // 停止游戏
            GameOver();
        }
    }

    private void UpdateBloodText()
    {
        // 更新屏幕上的血量显示
        bloodText.text = "Blood: " + blood;
    }

    private void GameOver()
    {
        player = GameObject.Find("Player");
        overText.gameObject.SetActive(true);
        Destroy(player);
        Time.timeScale = 0;
    }

}
