using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_C : MonoBehaviour, IEnemy
{
    public void Create(GameObject obj, Transform parent)
    {
        Instantiate(obj, parent);
        Debug.Log("CÃâ·Â");
    }
}
