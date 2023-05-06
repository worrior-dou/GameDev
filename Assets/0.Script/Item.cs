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
                    //coin���� ����
                    break;
                case "boom":
                    //boom �߻�
                    break;
                case "power":
                    //�Ѿ� ���׷��̵�
                    break;
            }
        }
        
    }
}
