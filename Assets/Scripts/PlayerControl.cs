using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))] // 请求添加2D的盒型碰撞体

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;  // 控制移动速度
    public GameObject bulletPrefab; // 子弹预制体
    public Transform firePoint; // 子弹发射位置
    private GameObject bg;
    private float bgWidth;
    private float playerWidth;
    // Start is called before the first frame update
    void Start()
    {
        bg = GameObject.Find("bg");
        bgWidth = bg.GetComponent<SpriteRenderer>().bounds.size.x;
        playerWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // 获取水平输入
        float moveInput = Input.GetAxis("Horizontal");

        // 计算移动
        Vector3 move = new Vector2(moveInput * moveSpeed * Time.deltaTime, 0);

        // 应用移动前，计算新的位置并限制在背景范围内
        Vector3 newPosition = transform.position + move;
        newPosition.x = Mathf.Clamp(newPosition.x, -bgWidth / 2 + playerWidth, bgWidth / 2 - playerWidth);

        // 应用移动
        transform.position = newPosition;

        // 发射子弹
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 创建子弹
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
