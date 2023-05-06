using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string type;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * 1.5f;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            switch (type)
            {
                case "coin":
                    //coin점수 증가
                    break;
                case "boom":
                    //boom 발생
                    break;
                case "power":
                    //총알 업그레이드
                    break;
            }
        }
        
    }
}
