using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_e : MonoBehaviour
{
    public float speed = 2f;
    Transform parent;
    Transform parentTemp;
    Sprite sp;

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

    public void SetSprite(Sprite sp)
    {
        this.sp = GetComponent<Sprite>();
    }

    void Start()
    {
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
