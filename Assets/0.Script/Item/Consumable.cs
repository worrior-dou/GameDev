using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public Item item;
    Rigidbody2D rgbd;

    void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rgbd.position += Vector2.down * Time.deltaTime * 1f;
    }
}
