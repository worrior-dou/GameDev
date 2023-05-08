using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_e : MonoBehaviour
{
    public float speed = 1f;
    [HideInInspector] public Transform parent;
    Transform parentTemp;
    public Sprite[] bulletSprite;
    public SpriteRenderer sr;

    public void SetData(float speed, Transform parent, Transform parentTemp)
    {
        this.speed = speed;
        this.parent = parent;
        this.parentTemp = parentTemp;
        SetParentTemp();
        SetSprite(sr.sprite);
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
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // 멀리가면 : 비활성화, 객체 재활용
        if (transform.localPosition.y < -10f)
            ReadyForPool();
        if (parent is null)
            ReadyForPool();

    }
    void ReadyForPool()
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        BulletPool.Instance.ReturnBE(this);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet_p bullet = collision.gameObject.GetComponent<Bullet_p>();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
