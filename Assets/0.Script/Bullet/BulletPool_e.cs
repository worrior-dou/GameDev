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
    //��ȿ�� �˻�
    public bool CheckPool()
    {
        if (pools.Count == 0)
            return true;
        return false;
    }
    //����
    public GameObject CreateBP(Transform parent, Transform parentTemp)
    {
        Bullet_e b = Instantiate(bullet, parent);
        b.SetParents(parent, parentTemp);
        pools.Enqueue(b);
        return b.gameObject;
    }
    //��Ȱ��
    public void ReturnBP(Bullet_e b)
    {
        pools.Enqueue(b);
    }
    //Ȱ��
    public void Play()
    {
        Bullet_e b = pools.Dequeue();        
        b.SetParentTemp();
        b.gameObject.SetActive(true);
    }

    //�Ѿ��� temp�� ��� �����ϰ� ���ֱ�
}
