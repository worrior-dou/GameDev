using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_C : MonoBehaviour, IEnemy
{
    float x;
    bool dir = true;//������
    float speedX = 0.2f;
    float speedY = 2f;
    float screen_left = -3f, screen_right = 3f;

    void Update()
    {
        Move();
    }

    public void Create(GameObject obj, Transform parent)
    {
        Instantiate(obj, parent);
        //Debug.Log("C���");
    }
    public void Move()
    {
        //�¿� ������
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
