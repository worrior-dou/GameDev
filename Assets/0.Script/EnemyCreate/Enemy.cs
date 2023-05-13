using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    public EnemyStat enemyStat;
    int score;
    int health;
    SpriteRenderer sr;
    Player player;

    Transform parentBullet;
    Transform parentBullet2 = null;

    Transform parentTemp;

    float angle = 180f;
    float radiusX = 1f;
    float radiusY = 1f;
    float speed = 3f;

    float screen_left = -3f, screen_right = 3f;

    Vector3 center;

    protected EnemyType type;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Player>();
        if (enemyStat != null)
        {
            score = enemyStat.scorePoint;
            health = enemyStat.health;
        }
        center = transform.position;
    }

    public void SetParent(Transform parentTemp)
    {
        //this.parentBullet = transform.Find("Turret")
        this.parentBullet = transform.GetChild(0);
        if (type == EnemyType.C)
        {
            this.parentBullet2 = transform.GetChild(1);
        }
        this.parentTemp = parentTemp;
    }

    void Update()
    {
        if (transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }

        Fire();

        MoveChange(type);
    }

    void Fire()
    {
        if (!Input.GetKeyDown(KeyCode.F1))
            return;
        //½´ÆÃ
        if (BulletPool_e.Instance.CheckPool())
        {
            SetParent(parentTemp);
            GameObject bullet = BulletPool_e.Instance.CreateBP(parentBullet, parentTemp);
            if (parentBullet2 != null)
            {
                GameObject bullet2 = BulletPool_e.Instance.CreateBP(parentBullet2, parentTemp);
            }
        }
        BulletPool_e.Instance.Play();
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

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet_p bullet = collision.gameObject.GetComponent<Bullet_p>();
            OnHit(bullet.dmg);
        }
    }

    void MoveChange(EnemyType type)
    {
        //¹«ºù
        switch (type)
        {
            case EnemyType.A:
                Move();
                break;
            case EnemyType.B:
                MoveHorizontal(0.1f, 10f);
                break;
            case EnemyType.C:
                MoveHorizontal(0.2f, 2f);
                break;
        }
    }

    protected void MoveHorizontal(float speedX, float speedY)
    {
        float x;
        bool dir = true;//¿À¸¥ÂÊ
        float screen_left = -3f, screen_right = 3f;

        //ÁÂ¿ì ¿òÁ÷ÀÓ
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
    void Move()
    {
        //ºù±Ûºù±Û
        angle += speed * Time.deltaTime;
        float x = center.x + Mathf.Cos(angle) * radiusX;
        float y = center.y + Mathf.Sin(angle) * radiusY;
        float clampX = Mathf.Clamp(x, screen_left, screen_right);
        //float clampY = Mathf.Clamp(y, screen_bottom, screen_top);
        //Á¶±Ý¾¿ ³»·Á¿È
        center.y -= 0.6f * Time.deltaTime;

        transform.position = new Vector3(clampX, y, transform.position.z);
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
