using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController_e : Singletone<BulletController_e>
{
    [SerializeField] private Transform parent;
    private Transform parentTemp;

    public float speed = 5f;

    void Start()
    {
        parentTemp = GameObject.Find("Temp_parent").transform;
    }
    void Update()
    {
        Play();
    }

    void Shooting()
    {        
        BulletPool.Instance.CreateBE(speed, parent, parentTemp);
    }

    float delayTimer = 0;
    void Play()
    {
        delayTimer += Time.deltaTime;
        if (delayTimer > 1f)
        {
            delayTimer = 0;
            if (BulletPool.Instance.CheckPoolE())
                Shooting();

            BulletPool.Instance.PlayE();
        }
    }
}
