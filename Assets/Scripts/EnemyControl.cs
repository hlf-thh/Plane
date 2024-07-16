using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed = 5f;
    private bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            isHit = true;
            Destroy(collision.gameObject); // 子弹
            Destroy(gameObject); // 敌机
        }

        if (collision.CompareTag("Player"))
        {
            isHit = true;
            // 扣血逻辑
            BloodManger.instance.DelBlood(1);
            Destroy(gameObject); // 敌机
        }
    }

    private void OnBecameInvisible()
    {
        if (!isHit)
        {
            ScoreManager.instance.DelScore(2); // 没打中减两分
        }
        else
        {
            ScoreManager.instance.AddScore(1);  // 增加分数
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        // 使敌机持续向下移动
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
