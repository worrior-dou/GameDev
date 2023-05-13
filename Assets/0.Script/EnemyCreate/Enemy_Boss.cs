using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss : Enemy
{
    void Update()
    {
        MoveHorizontal(0.2f, 0f);
    }
}
