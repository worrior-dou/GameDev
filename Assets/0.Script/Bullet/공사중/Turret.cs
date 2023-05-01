using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public static Turret Instance;
    void Awake()
    {
        Instance = this;
    }

    public void LookPlayer(Transform playerPos)
    {
        if (playerPos != null)
        {
            //플레이어 쳐다보기
            Vector2 vec = transform.position - playerPos.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        else
            transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
}
