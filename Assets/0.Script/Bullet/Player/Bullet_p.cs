using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_p : MonoBehaviour
{
    float speed;
    Transform parent;
    Transform parentTemp;

    public void SetData(float speed, Transform parent, Transform parentTemp)
    {
        this.speed = speed;
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
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // 멀리가면 : 비활성화, 객체 재활용
        if (transform.localPosition.y > 8f)
            ReadyForPool();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 총알이 몬스터한테 적중한 경우 : 총알 비활성화
        if (collision.gameObject.tag=="Enemy")
        {
            ReadyForPool();
            Destroy(collision.gameObject);
            Debug.Log("Hit!");
        }
    }

    void ReadyForPool()
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        BulletPool.Instance.ReturnBP(this);
        gameObject.SetActive(false);
    }
}
