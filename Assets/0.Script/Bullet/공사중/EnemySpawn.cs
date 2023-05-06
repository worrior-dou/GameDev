using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //전략패턴 연습
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
