using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool_e : Singletone<BulletPool_e>
{
    //Player
    public Bullet_e bullet;
    Queue<Bullet_e> pools = new Queue<Bullet_e>();

    void Start()
    {
        //P
        for (int i = 0; i < transform.childCount; i++)
        {
            pools.Enqueue(transform.GetChild(i).GetComponent<Bullet_e>());
        }
    }
    //유효성 검사
    public bool CheckPool()
    {
        if (pools.Count == 0)
            return true;
        return false;
    }
    //생성
    public GameObject CreateBP(Transform parent, Transform parentTemp)
    {
        Bullet_e b = Instantiate(bullet, parent);
        b.SetParents(parent, parentTemp);
        pools.Enqueue(b);
        return b.gameObject;
    }
    //재활용
    public void ReturnBP(Bullet_e b)
    {
        pools.Enqueue(b);
    }
    //활용
    public void Play()
    {
        Bullet_e b = pools.Dequeue();        
        b.SetParentTemp();
        b.gameObject.SetActive(true);
    }

    //총알이 temp에 계속 상주하게 해주기
}
