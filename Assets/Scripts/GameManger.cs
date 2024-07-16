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

    public float interval = 0.5f;  // ���ɵл���ʱ����
    private GameObject bg;  // ��������
    private float bgWidth;  // �����Ŀ��
    private float enemyWidth;  // �л��Ŀ��

    void Start()
    {

        // ��ȡ��������
        bg = GameObject.Find("bg");
        // ��ȡ�����Ŀ��
        bgWidth = bg.GetComponent<SpriteRenderer>().bounds.size.x;

        InitPlayer();

        // �л����
        GameObject tempEnemy = Instantiate(enemyPrefabA);
        enemyWidth = tempEnemy.GetComponent<SpriteRenderer>().bounds.size.x;
        Destroy(tempEnemy);

        // ��ʱ����
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
            // ��ȡ��Ļ�ײ����ĵ���������
            Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 0));
            spawnPosition.z = 0; 
            spawnPosition.y += selectedPlayerPrefab.GetComponent<SpriteRenderer>().bounds.size.y / 2; 

            // ����ѡ�еķɻ�
            Instantiate(selectedPlayerPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("No player prefab selected!");
        }

    }

    private void SpawnEnemy()
    {

        // �������ɵл���X��λ�ã�ȷ���ڱ�����Χ�ڲ����ǵл����
        float x = Random.Range(-bgWidth / 2 + enemyWidth / 2, bgWidth / 2 - enemyWidth / 2);
        // ��������λ��
        Vector3 spawnPosition = new Vector3(x, Camera.main.orthographicSize + 1, -0.5f);


        // ���ѡ��һ���л�Ԥ����
        GameObject[] enemyPrefabs = { enemyPrefabA, enemyPrefabB, enemyPrefabC };
        GameObject selectedEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // ���ɵл�
        Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
