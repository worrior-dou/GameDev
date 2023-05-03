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
        //범위 바깥(y=-10)으로 나갈 시, y=10위치로 이동
        if (transform.position.y < -10f)
        {
            transform.position += Vector3.up * 20f;
        }
    }
}
