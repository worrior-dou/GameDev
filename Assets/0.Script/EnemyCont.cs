using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MoveStrategy
{
    void Move(Transform transform);
}

public class EnemyCont : MonoBehaviour
{
    [SerializeField] private Enemy e;
    [SerializeField] private Transform parent;
    [SerializeField] private List<DataScript> datas;

    float spawnTimer = 0;

    public static EnemyCont Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if ( parent.childCount < 5)
            Invoke("CreateEnemy", 3f);
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > 2f)
        {
            spawnTimer = 0;
        }
    }
    void CreateEnemy()
    {
        Enemy e = Instantiate(this.e, parent);
        //랜덤 몬스터 생성
        int rand = Random.Range(0, datas.Count);
        Debug.Log(rand);
        e.SetData(datas[rand]);
    }
}
