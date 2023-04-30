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

        if (transform.localPosition.y > 8f)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
            BulletPool.Instance.ReturnObj(this);
            gameObject.SetActive(false);
        }
    }
}
