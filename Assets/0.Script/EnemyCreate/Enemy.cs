using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStat enemyStat;
    private IEnemy enemy;
    int score;
    int health;
    SpriteRenderer sr;
    Player player;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Start()
    {
        score = enemyStat.scorePoint;
        health = enemyStat.health;
    }
    void Update()
    {
        if (transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
    }

    public void setEnemy(IEnemy enemy)
    {
        this.enemy = enemy;
    }

    public void OnHit(int dmg)
    {
        health -= dmg;
        sr.color = new Color(0.75f, 0.75f, 0.75f, 1f);
        Invoke("ReturnColor", 0.2f);
        if (health <= 0)
        {
            player.score += score;
            Destroy(gameObject);
        }
    }
    void ReturnColor()
    {
        sr.color = new Color(1f, 1f, 1f, 1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet_p bullet = collision.gameObject.GetComponent<Bullet_p>();
            OnHit(bullet.dmg);
        }
    }
}
