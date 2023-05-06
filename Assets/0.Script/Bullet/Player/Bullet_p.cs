using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_p : MonoBehaviour
{
    float speed;
    public int dmg;
    Transform parent;
    Transform parentTemp;
    SpriteRenderer sr;

    public void SetBulletStat(int dmg, float speed)
    {
        this.dmg = dmg;
        this.speed = speed;
    }
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
    public void SetSprite(Sprite sp)
    {
        this.sr.sprite = sp;
    }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // �ָ����� : ��Ȱ��ȭ + ��ü ��Ȱ��
        if (transform.localPosition.y > 10f)
            ReadyForPool();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Ѿ��� �������� ������ ��� : �Ѿ� ��Ȱ��ȭ
        if (collision.gameObject.tag == "Enemy")
        {
            ReadyForPool();
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
