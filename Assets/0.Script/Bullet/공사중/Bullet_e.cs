using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_e : MonoBehaviour
{
    public float speed = 2f;
    Transform parent;
    Transform parentTemp;

    public void SetData(Transform parent, Transform parentTemp)
    {
        this.parent = parent;
        this.parentTemp = parentTemp;
    }

    void Update()
    {
        transform.SetParent(parentTemp);
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.localPosition.y < -10)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector2.zero;
            //ObjectPool.Instance.ReturnObj(gameObject);
            gameObject.SetActive(false);
        }
    }
}
