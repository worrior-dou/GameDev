using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool_e : Singletone<BulletPool_e>
{
    //Player
    public Bullet_e bullet;
    Queue<Bullet_e> pools = new Queue<Bullet_e>();

    [SerializeField] private Transform parentTemp;

    void Start()
    {
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
    public GameObject CreateBP()
    {
        Bullet_e b = Instantiate(bullet, parentTemp);
        pools.Enqueue(b);
        return b.gameObject;
    }
    //��Ȱ��
    public void ReturnBP(Bullet_e b)
    {
        b.transform.SetParent(parentTemp);
        pools.Enqueue(b);
    }
    //Ȱ��
    public Bullet_e Play(Transform parent)
    {
        Bullet_e b = pools.Dequeue();
        b.transform.SetParent(parent);
        b.transform.localPosition = Vector3.zero;
        b.gameObject.SetActive(true);
        return b;
    }

    public Transform SetParentTemp()
    {
        return parentTemp;
    }
}
