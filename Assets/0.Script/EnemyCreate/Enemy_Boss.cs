using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss : Enemy, IEnemy
{
    void Update()
    {
        MoveHorizontal(0.2f, 0f);
    }

    public void Create(GameObject obj, Transform parent)
    {
        Instantiate(obj, parent);
    }
}
