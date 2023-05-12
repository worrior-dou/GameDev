using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet_e : MonoBehaviour
{
    float speed = 5f;
    private IObjectPool<Bullet_e> bulletPool;
    //Transform turretTransform;

    public void SetPool(IObjectPool<Bullet_e> pool)
    {
        bulletPool = pool;
    }

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        bulletPool.Release(this);
    }
}
