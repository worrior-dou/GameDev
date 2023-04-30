using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShift : MonoBehaviour, MoveStrategy
{
    private float x;
    private bool dir = true;
    private float pastTime;

    public void Move(Transform transform)
    {
        pastTime += Time.deltaTime * 1f;
        if (dir == true)
        {
            x = Time.deltaTime * 1f;
            if (pastTime > 3f)
            {
                dir = false;
                pastTime = 0f;
            }
        }
        else
        {
            x = Time.deltaTime * -1f;
            if (pastTime > 3f)
            {
                dir = true;
                pastTime = 0f;
            }
        }
        transform.Translate(new Vector3(x, 0f, 0f));
    }
}
