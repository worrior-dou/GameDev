using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public SpriteRenderer sr;

    float speed;
    DataScript data;
    Transform parent;
    Transform parentTemp;

    public void SetData(DataScript data)
    {
        this.data = data;
        this.sr.sprite = data.Sprite;
        this.speed = data.Speed;
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //랜덤위치(x) 생성
        float rand = Random.Range(-2.7f, 2.7f);
        transform.position = new Vector3(rand, 5f, 0f);
    }
        
    void Update()
    {

    }
}
