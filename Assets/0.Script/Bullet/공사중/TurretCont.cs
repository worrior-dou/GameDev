using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ShootStrategy
{
    void Shoot(int amount);
}

public class TurretCont : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private Transform parent;
    [SerializeField] private Transform parentTemp;

    void Start()
    {
    }

    void Update()
    {
        //플레이어 쳐다보기
        {
            Vector2 vec = transform.position - playerPos.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
}
