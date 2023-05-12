using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_B : Enemy, IEnemy
{
    float speedX = 0.1f;
    float speedY= 10f;

    void Update()
    {
        MoveHorizontal(speedX, speedY);
    }

    public void Create(GameObject obj, Transform parent)
    {
        Instantiate(obj, parent);
    }
}
