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
        // ȷ��ֻ��һ�� ScoreManager ʵ��
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
       
        // ��ʼ��Ѫ����ʾ
        UpdateBloodText();
    }

    public void DelBlood(int points)
    {
        // ����Ѫ����������ʾ
        blood -= points;
        UpdateBloodText();
        if(blood == 0)
        {
            // ֹͣ��Ϸ
            GameOver();
        }
    }

    private void UpdateBloodText()
    {
        // ������Ļ�ϵ�Ѫ����ʾ
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
