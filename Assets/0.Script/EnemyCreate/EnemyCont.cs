using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    A, B, C, Boss
}

public class EnemyCont : Singletone<EnemyCont>
{
    //스폰
    [SerializeField] private Transform[] parentT;
    [SerializeField] private Transform parentBoss;
    //총알
    public Transform parentTemp;
    EnemyStat stat;

    public GameObject _enemyA;
    public GameObject _enemyB;
    public GameObject _enemyC;
    public GameObject _enemyBoss;

    GameObject obj;

    bool isBoss = false;

    void Awake()
    {
        obj = GetComponent<GameObject>();
    }

    private void SetEnemyType(EnemyType type)
    {
        switch (type)
        {
            default:
            case EnemyType.A:
                obj = _enemyA;
                break;
            case EnemyType.B:
                obj = _enemyB;
                break;
            case EnemyType.C:
                obj = _enemyC;
                break;
            case EnemyType.Boss:
                obj = _enemyBoss;
                break;
        }
    }

    //적 생성
    private float spawnTimer = 0;
    private float spawnTimerBoss = 0;
    void Update()
    {
        spawnTimer += Time.deltaTime;
        int rand = Random.Range(0, 4);
        if (spawnTimer > Random.Range(2f, 4f))
        {
            spawnTimer = 0;
            if (parentT[rand].childCount < 5)
            {
                SetEnemyType((EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length-1));
                Create(obj, parentT[rand]);
            }
        }

        //보스 생성
        spawnTimerBoss += Time.deltaTime;
        if (spawnTimerBoss > 10f && isBoss == false)
        {
            isBoss = true;
            spawnTimer = 0;
            SetEnemyType(EnemyType.Boss);
            Create(obj, parentBoss);
        }
    }
    public void Create(GameObject obj, Transform parent)
    {
        Instantiate(obj, parent);
    }
}
