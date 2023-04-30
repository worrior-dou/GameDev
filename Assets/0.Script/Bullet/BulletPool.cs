using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : Singletone<BulletPool>
{
    public Bullet_p bullet;
    Queue<Bullet_p> pools = new Queue<Bullet_p>();

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            pools.Enqueue(transform.GetChild(i).GetComponent<Bullet_p>());
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

    //생성
    void CreateObj()
    {
        Bullet_p b = Instantiate(bullet, transform);
        pools.Enqueue(b);
    }

    public void CreateObj(float speed, Transform parent, Transform parentTemp)
    {
        Bullet_p b = Instantiate(bullet, parent);
        b.SetData(speed, parent, parentTemp);
        pools.Enqueue(b);
    }

    //재활용
    public void ReturnObj(Bullet_p b)
    {
        pools.Enqueue(b);
    }

    //활용
    public void Play()
    {
        Bullet_p b = pools.Dequeue();
        b.SetParentTemp();
        b.gameObject.SetActive(true);
    }
}
