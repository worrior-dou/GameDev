using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_B : Enemy, IEnemy
{
    void Update()
    {
        MoveHorizontal(0.1f, 10f);
    }

    public void Create(GameObject obj, Transform parent)
    {
        Instantiate(obj, parent);
    }
}
