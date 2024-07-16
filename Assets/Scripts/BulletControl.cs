using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;  // �ӵ����ƶ��ٶ�
    public float lifetime = 5f;  // �ӵ�������ʱ�䣬��ֹ�ӵ���Զ����

    void Start()
    {
        // ������ʱ������������ӵ�
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // ʹ�ӵ������ƶ�
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        // ���ӵ��뿪��Ļʱ����
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // ����ӵ��Ƿ���ײ���л�
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);  // ���ٵл�
            Destroy(gameObject);  // �����ӵ�
        }
    }
}
