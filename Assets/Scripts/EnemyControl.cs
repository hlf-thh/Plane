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
            Destroy(collision.gameObject); // �ӵ�
            Destroy(gameObject); // �л�
        }

        if (collision.CompareTag("Player"))
        {
            isHit = true;
            // ��Ѫ�߼�
            BloodManger.instance.DelBlood(1);
            Destroy(gameObject); // �л�
        }
    }

    private void OnBecameInvisible()
    {
        if (!isHit)
        {
            ScoreManager.instance.DelScore(2); // û���м�����
        }
        else
        {
            ScoreManager.instance.AddScore(1);  // ���ӷ���
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        // ʹ�л����������ƶ�
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
