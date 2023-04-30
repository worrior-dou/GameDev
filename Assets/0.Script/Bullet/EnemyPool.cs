using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : Singletone<EnemyPool>
{
    [SerializeField] DataScript data;
    public Enemy enemy;
    Queue<Enemy> pools = new Queue<Enemy>();

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            pools.Enqueue(transform.GetChild(i).GetComponent<Enemy>());
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
        Enemy b = Instantiate(enemy, transform);
        pools.Enqueue(b);
    }

    public void CreateObj(float speed, Transform parent, Transform parentTemp)
    {
        Enemy e = Instantiate(enemy, parent);
        e.SetData();
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
