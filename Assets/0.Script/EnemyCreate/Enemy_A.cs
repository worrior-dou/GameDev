using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_A : Enemy, IEnemy
{
    Vector3 center;
    float angle = 180f;
    float radiusX = 1f;
    float radiusY = 1f;
    float speed = 3f;

    float screen_left = -3f, screen_right = 3f;

    void Start()
    {
        center = transform.position;
    }
    void Update()
    {
        Move();
    }
    public void Create(GameObject obj, Transform parent)
    {
        Instantiate(obj, parent);
    }

    public void Move()
    {
        //ºù±Ûºù±Û
        angle += speed * Time.deltaTime;
        float x = center.x + Mathf.Cos(angle) * radiusX;
        float y = center.y + Mathf.Sin(angle) * radiusY;
        float clampX = Mathf.Clamp(x, screen_left, screen_right);
        //float clampY = Mathf.Clamp(y, screen_bottom, screen_top);
        //Á¶±Ý¾¿ ³»·Á¿È
        center.y -= 0.6f * Time.deltaTime;

        transform.position = new Vector3(clampX, y, transform.position.z);
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
