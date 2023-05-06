using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_A : MonoBehaviour, IEnemy
{
    float x;
    bool dir = true;//������
    float speedX = 2f;
    float speedY = 1f;
    float screen_left = -3f, screen_right = 3f;
    void Update()
    {
        Move();
    }
    public void Create(GameObject obj, Transform parent)
    {
        Instantiate(obj, parent);
        //Debug.Log("A���");
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
