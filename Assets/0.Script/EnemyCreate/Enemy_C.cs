using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_C : Enemy, IEnemy
{
    float speedX = 0.2f;
    float speedY = 2f;

    void Update()
    {
        MoveHorizontal(speedX, speedY);
    }

    public void Create(GameObject obj, Transform parent)
    {
        Instantiate(obj, parent);
    }
}
