using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_e : MonoBehaviour
{
    public float speed = 2f;
    Transform parent;
    Transform parentTemp;
    public Sprite[] bulletSprite;
    public SpriteRenderer sr;

    public void SetData(float speed, Transform parent, Transform parentTemp)
    {
        this.speed = speed;
        this.parent = parent;
        this.parentTemp = parentTemp;
        SetParentTemp();
        SetSprite(parent, sr.sprite);
    }

    public void SetParentTemp()
    {
        transform.SetParent(parentTemp);
    }

    public void SetSprite(Transform parent, Sprite sp)
    {
        switch (parent.name)
        {
            default:
            case "TurretA":
                sp = bulletSprite[0];
                break;
            case "TurretB":
                sp = bulletSprite[1];
                break;
            case "TurretL":
            case "TurretR":
                sp = bulletSprite[2];
                break;

        }
    }

    void Start()
    {
        //Debug.Log(parent.name);
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // 멀리가면 : 비활성화, 객체 재활용
        if (transform.localPosition.y < -10f)
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
}
