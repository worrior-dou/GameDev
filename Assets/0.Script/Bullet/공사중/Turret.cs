using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;        
    }

    void Update()
    {
        //�÷��̾� �Ĵٺ���
        Vector2 vec = transform.position - player.position;
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}