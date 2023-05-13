using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet_e : MonoBehaviour
{
    float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);       
        
        // �ָ����� : ��Ȱ��ȭ + ��ü ��Ȱ��
        if (transform.localPosition.y < -10f)
            ReadyForPool();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerBullet") || collision.tag.Equals("Player"))
        {
            ReadyForPool();
        }
    }

    void ReadyForPool()
    {
        Debug.Log("------");
        BulletPool_e.Instance.ReturnBP(this);
        gameObject.SetActive(false);
    }

    void OnBecameVisible()
    {

    }
}
