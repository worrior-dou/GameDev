using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IEnemy enemy;
    public int health;
    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void setEnemy(IEnemy enemy)
    {
        this.enemy = enemy;
    }

    void OnHit(int dmg)
    {
        health -= dmg;
        sr.color = new Color(0.75f, 0.75f, 0.75f, 1f);
        Invoke("ReturnColor", 0.2f);
        if (health <= 0)
        {
            Destroy(this.gameObject);
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
