using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //�������� ����
    private IEnemy enemy;

    public void setEnemy(IEnemy enemy)
    {
        this.enemy = enemy;
    }
    public void Create(GameObject obj)
    {
        //Debug.Log(obj.name);
    }
}
