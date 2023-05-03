using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCont : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    Turret turret;

    void Start()
    {
    }

    void Update()
    {
        Turret.Instance.LookPlayer(playerPos);
    }
}
