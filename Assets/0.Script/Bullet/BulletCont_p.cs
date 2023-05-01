using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCont_p : Singletone<BulletCont_p>
{
    [SerializeField] private Transform parent;
    [SerializeField] private Transform parentTemp;

    public float speed = 5f;
    void Start()
    {
    }

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
        BulletPool.Instance.CreateObj(speed, parent, parentTemp);
    }
}
