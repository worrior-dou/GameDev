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

    //��ȿ�� �˻�
    public bool CheckPool()
    {
        if (pools.Count == 0)
            return true;
        return false;
    }

    //����
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

    //��Ȱ��
    public void ReturnObj(Bullet_p b)
    {
        pools.Enqueue(b);
    }

    //Ȱ��
    public void Play()
    {
        Bullet_p b = pools.Dequeue();
        b.SetParentTemp();
        b.gameObject.SetActive(true);
    }
}
