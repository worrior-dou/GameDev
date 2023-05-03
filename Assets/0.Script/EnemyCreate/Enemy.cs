using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IEnemy enemy;

    public void setEnemy(IEnemy enemy)
    {
        this.enemy = enemy;
    }
}
