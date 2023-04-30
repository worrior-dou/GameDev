using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]

public class DataScript : ScriptableObject
{
    //인덱스
    [SerializeField] private int index;
    public int Index { get { return index; } }

    //이름
    [SerializeField] private string Obj_name;
    public string Name { get { return Obj_name; } }

    //스프라이트
    [SerializeField] private Sprite sprite;
    public Sprite Sprite { get { return sprite; } }
    //체력
    [SerializeField] private int hp;
    public int Hp { get { return hp; } }
    //속도
    [SerializeField] private float speed;
    public float Speed { get { return speed; } }
    //공격력
    [SerializeField] private float atk;
    public float Atk { get { return atk; } }
    //딜레이
    [SerializeField] private float delay;
    public float Delay { get { return delay; } }
    //총알
    [SerializeField] private Bullet_e bullet;
    public Bullet_e Bullet { get { return bullet; } }

}
