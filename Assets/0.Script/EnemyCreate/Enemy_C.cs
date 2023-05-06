using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_C : MonoBehaviour, IEnemy
{
    float x;
    bool dir = true;//오른쪽
    float speedX = 1f;
    float speedY = 0.25f;
    float screen_left = -3f, screen_right = 3f;

    void Update()
    {
        Move();
    }

    public void Create(GameObject obj, Transform parent)
    {
        Instantiate(obj, parent);
        //Debug.Log("C출력");
    }
    public void Move()
    {
        //좌우 움직임
        if (dir == true)
        {
            x = Time.deltaTime * speedX;
            if (transform.position.x > screen_right)
                dir = false;
        }
        else
        {
            x = Time.deltaTime * -speedX;
            if (transform.position.x < screen_left)
                dir = true;
        }

        transform.Translate(x, -1f * Time.deltaTime * speedY, 0f);
    }
}
