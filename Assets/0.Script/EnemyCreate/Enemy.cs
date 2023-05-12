using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private IEnemy enemy;
    public EnemyStat enemyStat;
    int score;
    int health;
    SpriteRenderer sr;
    Player player;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Player>();
        if (enemyStat != null)
        {
            score = enemyStat.scorePoint;
            health = enemyStat.health;
        }
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
    protected void ReturnColor()
    {
        sr.color = new Color(1f, 1f, 1f, 1f);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet_p bullet = collision.gameObject.GetComponent<Bullet_p>();
            OnHit(bullet.dmg);
        }
    }

    protected void MoveHorizontal(float speedX, float speedY)
    {
        float x;
        bool dir = true;//오른쪽
        float screen_left = -3f, screen_right = 3f;

        //좌우 움직임
        if (dir == true)
        {
            x = Time.deltaTime * speedX;
            if (transform.position.x > screen_right)
                dir = false;
        }
        else
        {
            x = Time.deltaTime * -speedX;
            if (transform.position.x < screen_left)
                dir = true;
        }

        transform.Translate(x, -1f * Time.deltaTime * speedY, 0f);
    }
}
