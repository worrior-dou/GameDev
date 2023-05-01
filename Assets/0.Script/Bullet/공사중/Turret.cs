using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Transform playerPos;

    public static Turret Instance;
    void Awake()
    {
        Instance = this;
    }

    public void LookPlayer(Transform playerPos)
    {
        //�÷��̾� �Ĵٺ���
        {
            Vector2 vec = transform.position - playerPos.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
}
