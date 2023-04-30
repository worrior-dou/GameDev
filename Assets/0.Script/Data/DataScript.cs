using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]

public class DataScript : ScriptableObject
{
    //�ε���
    [SerializeField] private int index;
    public int Index { get { return index; } }

    //�̸�
    [SerializeField] private string Obj_name;
    public string Name { get { return Obj_name; } }

    //��������Ʈ
    [SerializeField] private Sprite sprite;
    public Sprite Sprite { get { return sprite; } }
    //ü��
    [SerializeField] private int hp;
    public int Hp { get { return hp; } }
    //�ӵ�
    [SerializeField] private float speed;
    public float Speed { get { return speed; } }
    //���ݷ�
    [SerializeField] private float atk;
    public float Atk { get { return atk; } }
    //������
    [SerializeField] private float delay;
    public float Delay { get { return delay; } }
    //�Ѿ�
    [SerializeField] private Bullet_e bullet;
    public Bullet_e Bullet { get { return bullet; } }

}
