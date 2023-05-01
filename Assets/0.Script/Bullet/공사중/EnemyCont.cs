using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    A, B, C, Boss
}

public class EnemyCont : MonoBehaviour
{
    [SerializeField] private Transform parent;

    public GameObject _enemyA;
    public GameObject _enemyB;
    public GameObject _enemyC;

    private GameObject obj;

    private IEnemy enemy;

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
        }
    }

    void Start()
    {
        //SetEnemyType(EnemyType.B);
    }

    //적 생성
    private float spawnTimer = 0;
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > 1f)
        {
            spawnTimer = 0;
            if (parent.childCount < 10)
            {
                int rand = Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length);
                SetEnemyType((EnemyType)rand);
                Instantiate(obj, parent);
            }
        }
    }

    //전략
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

    public void Spawn()
    {
        //enemy.Shooting();
        enemy.Create(obj);
    }
}
