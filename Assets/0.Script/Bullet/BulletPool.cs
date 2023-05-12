using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : Singletone<BulletPool>
{
    //Player
    public Bullet_p bullet;
    Queue<Bullet_p> pools = new Queue<Bullet_p>();

    void Start()
    {
        //P
        for (int i = 0; i < transform.childCount; i++)
        {
            pools.Enqueue(transform.GetChild(i).GetComponent<Bullet_p>());
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
    public GameObject CreateBP(int dmg, float speed, Transform parent, Transform parentTemp, Sprite sp)
    {
        Bullet_p b = Instantiate(bullet, parent);
        b.SetBulletStat(dmg, speed);
        b.SetParents(parent, parentTemp);
        b.SetSprite(sp);
        pools.Enqueue(b);
        return b.gameObject;
    }
    //재활용
    public void ReturnBP(Bullet_p b)
    {
        pools.Enqueue(b);
    }
    //활용
    public void Play(int dmg, float speed, Sprite sp)
    {
        Bullet_p b = pools.Dequeue();
        b.SetBulletStat(dmg, speed);
        b.SetSprite(sp);
        b.SetParentTemp();
        b.gameObject.SetActive(true);
    }
}
