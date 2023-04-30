using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveRound : MonoBehaviour, MoveStrategy
{
    private Vector3 center;
    private float angle;
    private float radius;
    private float speed;

    public MoveRound(Vector3 center, float radius, float speed)
    {
        this.center = center;
        this.radius = radius;
        this.speed = speed;
    }

    public void Move(Transform transform)
    {
        angle += speed * Time.deltaTime;
        float x = center.x + Mathf.Cos(angle) * radius;
        float y = center.y + Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x, y, transform.position.z);
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
