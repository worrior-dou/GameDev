using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Turret : MonoBehaviour
{
    Transform player;

    [SerializeField] Bullet_e bulletPrefab;
    private IObjectPool<Bullet_e> bulletPool;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        bulletPool = new ObjectPool<Bullet_e>(CreateBullet, OnGet, OnRelease, OnDestroy, maxSize: 100);
    }

    //Pooling
    Bullet_e CreateBullet()
    {
        Bullet_e b = Instantiate(bulletPrefab, transform);
        b.SetPool(bulletPool);
        return b;
    }
    protected void OnGet(Bullet_e b)
    {
        b.transform.SetParent(EnemyCont.Instance.parentTemp);
        b.gameObject.SetActive(true);        
    }
    protected void OnRelease(Bullet_e b)
    {
        b.transform.SetParent(transform);
        b.gameObject.SetActive(false);
    }
    protected void OnDestroy(Bullet_e b)
    {
        Destroy(b.gameObject);
    }

    float delayTime = 0f;
    void Update()
    {
        //플레이어 쳐다보기
        Vector2 vec = transform.position - player.position;
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (bulletPool != null)
        {
            delayTime += Time.deltaTime;
            if (delayTime > 2f)
            {
                bulletPool.Get();
                delayTime = 0f;
            }
        }
    }
}