using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet_e : MonoBehaviour
{
    float speed = 5f;

    Transform parent;
    Transform parentTemp;

    public void SetParents(Transform parent, Transform parentTemp)
    {
        this.parent = parent;
        this.parentTemp = parentTemp;
        SetParentTemp();
    }
    public void SetParentTemp()
    {
        transform.SetParent(parentTemp);
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);       
        
        // 멀리가면 : 비활성화 + 객체 재활용
        if (transform.localPosition.y < -10f)
            ReadyForPool();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerBullet")|| collision.tag.Equals("Player"))
        {
            ReadyForPool();
        }
    }

    void ReadyForPool()
    {
        Debug.Log("------");
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        BulletPool_e.Instance.ReturnBP(this);
        gameObject.SetActive(false);
    }
}
