using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Transform player;
    GameObject bullet;
    Transform parentTemp;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        //플레이어 쳐다보기
        Vector2 vec = transform.position - player.position;
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        
        Fire();
    }

    float delayTime = 0;
    void Fire()
    {
        delayTime += Time.deltaTime;
        if (delayTime > 1.5f)
        {
            delayTime = 0f;
            //슈팅
            if (BulletPool_e.Instance.CheckPool())
            {
                bullet = BulletPool_e.Instance.CreateBP();
            }
            Bullet_e b = BulletPool_e.Instance.Play(transform);
            parentTemp = BulletPool_e.Instance.SetParentTemp();
            b.transform.SetParent(parentTemp);
            b.transform.rotation = transform.rotation;
        }        
    }
}