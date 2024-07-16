using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))] // �������2D�ĺ�����ײ��

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;  // �����ƶ��ٶ�
    public GameObject bulletPrefab; // �ӵ�Ԥ����
    public Transform firePoint; // �ӵ�����λ��
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
        // ��ȡˮƽ����
        float moveInput = Input.GetAxis("Horizontal");

        // �����ƶ�
        Vector3 move = new Vector2(moveInput * moveSpeed * Time.deltaTime, 0);

        // Ӧ���ƶ�ǰ�������µ�λ�ò������ڱ�����Χ��
        Vector3 newPosition = transform.position + move;
        newPosition.x = Mathf.Clamp(newPosition.x, -bgWidth / 2 + playerWidth, bgWidth / 2 - playerWidth);

        // Ӧ���ƶ�
        transform.position = newPosition;

        // �����ӵ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // �����ӵ�
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
