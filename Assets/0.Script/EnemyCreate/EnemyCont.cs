using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    A, B, C, Boss
}

public class EnemyCont : Singletone<EnemyCont>
{
    [SerializeField] private Transform[] parentT;
    [SerializeField] private Transform parentBoss;
    public Transform parentTemp;
    EnemyStat stat;

    public GameObject _enemyA;
    public GameObject _enemyB;
    public GameObject _enemyC;
    public GameObject _enemyBoss;

    private GameObject obj;

    private IEnemy enemy;
    private bool isBoss = false;

    private void SetEnemyType(EnemyType type)
    {
        Component c = gameObject.GetComponent<IEnemy>() as Component;

        switch (type)
        {
            default:
            case EnemyType.A:
                enemy = gameObject.AddComponent<Enemy_A>();
                obj = _enemyA;
                break;
            case EnemyType.B:
                enemy = gameObject.AddComponent<Enemy_B>();
                obj = _enemyB;
                break;
            case EnemyType.C:
                enemy = gameObject.AddComponent<Enemy_C>();
                obj = _enemyC;
                break;
            case EnemyType.Boss:
                enemy = gameObject.AddComponent<Enemy_Boss>();
                obj = _enemyBoss;
                break;
        }
    }

    //利 积己
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
                enemy.Create(obj, parentT[rand]);
            }
        }

        //焊胶 积己
        spawnTimerBoss += Time.deltaTime;
        if (spawnTimerBoss > 4f && isBoss == false)
        {
            isBoss = true;
            spawnTimer = 0;
            SetEnemyType(EnemyType.Boss);
            enemy.Create(obj, parentBoss);
        }
    }

    //傈帆
    public void ChangeEnemyA()
    {
        SetEnemyType(EnemyType.A);
    }
    public void ChangeEnemyB()
    {
        SetEnemyType(EnemyType.B);
    }
    public void ChangeEnemyC()
    {
        SetEnemyType(EnemyType.C);
    }
    public void ChangeEnemyBoss()
    {
        SetEnemyType(EnemyType.Boss);
    }
}
