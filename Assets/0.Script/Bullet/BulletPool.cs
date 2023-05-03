using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : Singletone<BulletPool>
{
    public Bullet_p bullet;
    Queue<Bullet_p> pools = new Queue<Bullet_p>();

    public Bullet_e bulletE;
    Queue<Bullet_e> poolsE = new Queue<Bullet_e>();

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            pools.Enqueue(transform.GetChild(i).GetComponent<Bullet_p>());
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            poolsE.Enqueue(transform.GetChild(i).GetComponent<Bullet_e>());
        }
    }
    void Update()
    {
    }

    //유효성 검사
    public bool CheckPool()
    {
        if (pools.Count == 0)
            return true;
        return false;
    }
    public bool CheckPoolE()
    {
        if (poolsE.Count == 0)
            return true;
        return false;
    }

    //생성
    public void CreateBP(float speed, Transform parent, Transform parentTemp)
    {
        Bullet_p b = Instantiate(bullet, parent);
        b.SetData(speed, parent, parentTemp);
        pools.Enqueue(b);
    }
    public void CreateBE(float speed, Transform parent, Transform parentTemp)
    {
        Bullet_e e = Instantiate(bulletE, parent);
        e.SetData(speed, parent, parentTemp);
        poolsE.Enqueue(e);
    }

    //재활용
    public void ReturnBP(Bullet_p b)
    {
        pools.Enqueue(b);
    }
    public void ReturnBE(Bullet_e e)
    {
        poolsE.Enqueue(e);
    }

    //활용
    public void Play()
    {
        Bullet_p b = pools.Dequeue();
        b.SetParentTemp();
        b.gameObject.SetActive(true);
    }
    public void PlayE()
    {
        Bullet_e e = poolsE.Dequeue();
        e.SetParentTemp();
        e.gameObject.SetActive(true);
    }

}
