using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyStat")]
public class EnemyStat : ScriptableObject
{
    public float speed;
    public int health;
    public int scorePoint;    
    public Sprite sprite;
    public enum EnemyType
    {
        BALL,
        TRI,
        RECT,
        BOSS
    }
    public EnemyType enemyType;
}
