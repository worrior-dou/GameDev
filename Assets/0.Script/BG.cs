using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public float speed;

    void Start()
    {
    }
    void Update()
    {
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position += nextPos;
        //���� �ٱ�(y=-10)���� ���� ��, y=10��ġ�� �̵�
        if (transform.position.y < -10f)
        {
            transform.position += Vector3.up * 20f;
        }
    }
}
