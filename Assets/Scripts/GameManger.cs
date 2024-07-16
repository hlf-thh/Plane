using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefabA;
    public GameObject enemyPrefabB;
    public GameObject enemyPrefabC;

    public GameObject playerPrefabA;
    public GameObject playerPrefabB;
    public GameObject playerPrefabC;

    public float interval = 0.5f;  // 生成敌机的时间间隔
    private GameObject bg;  // 背景对象
    private float bgWidth;  // 背景的宽度
    private float enemyWidth;  // 敌机的宽度

    void Start()
    {

        // 获取背景对象
        bg = GameObject.Find("bg");
        // 获取背景的宽度
        bgWidth = bg.GetComponent<SpriteRenderer>().bounds.size.x;

        InitPlayer();

        // 敌机宽度
        GameObject tempEnemy = Instantiate(enemyPrefabA);
        enemyWidth = tempEnemy.GetComponent<SpriteRenderer>().bounds.size.x;
        Destroy(tempEnemy);

        // 定时生成
        InvokeRepeating("SpawnEnemy", interval, interval);
    }

    void InitPlayer()
    {
        string selectedPlayerName = PlayerPrefs.GetString("SelectedPlayer");
        Debug.Log(selectedPlayerName);
        GameObject selectedPlayerPrefab = null;
        switch (selectedPlayerName)
        {
            case "planeA":
                selectedPlayerPrefab = playerPrefabA;
                break;
            case "planeB":
                selectedPlayerPrefab = playerPrefabB;
                break;
            case "planeC":
                selectedPlayerPrefab = playerPrefabC;
                break;
        }

        if (selectedPlayerPrefab != null)
        {
            // 获取屏幕底部中心的世界坐标
            Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 0));
            spawnPosition.z = 0; 
            spawnPosition.y += selectedPlayerPrefab.GetComponent<SpriteRenderer>().bounds.size.y / 2; 

            // 生成选中的飞机
            Instantiate(selectedPlayerPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("No player prefab selected!");
        }

    }

    private void SpawnEnemy()
    {

        // 计算生成敌机的X轴位置，确保在背景范围内并考虑敌机宽度
        float x = Random.Range(-bgWidth / 2 + enemyWidth / 2, bgWidth / 2 - enemyWidth / 2);
        // 设置生成位置
        Vector3 spawnPosition = new Vector3(x, Camera.main.orthographicSize + 1, -0.5f);


        // 随机选择一个敌机预制体
        GameObject[] enemyPrefabs = { enemyPrefabA, enemyPrefabB, enemyPrefabC };
        GameObject selectedEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // 生成敌机
        Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
