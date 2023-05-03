using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController_p : Singletone<BulletController_p>
{
    [SerializeField] private Transform parent;
    [SerializeField] private Transform parentTemp;

    public float speed = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (BulletPool.Instance.CheckPool())
                Shooting();

            BulletPool.Instance.Play();
        }
    }

    void Shooting()
    {
        BulletPool.Instance.CreateBP(speed, parent, parentTemp);
    }
}
