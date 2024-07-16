using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;  // 子弹的移动速度
    public float lifetime = 5f;  // 子弹的生存时间，防止子弹永远存在

    void Start()
    {
        // 在生存时间结束后销毁子弹
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // 使子弹向上移动
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        // 当子弹离开屏幕时销毁
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 检查子弹是否碰撞到敌机
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);  // 销毁敌机
            Destroy(gameObject);  // 销毁子弹
        }
    }
}
