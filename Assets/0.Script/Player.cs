using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float screen_left = -3f, screen_right = 3f;
    float screen_bottom = -5.3f, screen_top = 5f;

    public float speedMov = 5f, speedBullet = 5f;
    public float curShootDelay, maxShootDelay = 0.1f;
    public int power;
    public Sprite[] sp;

    public int lifeValue;
    public int score;
    public int moeny;

    SpriteRenderer sr;
    Animator anim;

    [SerializeField] private Transform parentTemp;
    [SerializeField] private UiManager UiManager;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        lifeValue = 3;
        UiManager.UpdateLifeIcon(lifeValue);
        score = 0;
        moeny = 0;
        power = 1;
    }

    void Update()
    {
        Move();
        Fire();
        Reload();
    }

    void Move()
    {
        //����Ű ����, �Ѱ�����
        float x = Input.GetAxisRaw("Horizontal") * speedMov * Time.deltaTime;
        float clampX = Mathf.Clamp(transform.position.x + x, screen_left, screen_right);
        float y = Input.GetAxisRaw("Vertical") * speedMov * Time.deltaTime;
        float clampY = Mathf.Clamp(transform.position.y + y, screen_bottom, screen_top);

        transform.position = new Vector2(clampX, clampY);

        //���⿡ ���� �̹��� ����(feat.Animator)
        if (Input.GetButtonDown("Horizontal") ||
            Input.GetButtonUp("Horizontal"))
        {
            anim.SetInteger("Input", (int)Input.GetAxisRaw("Horizontal"));
        }        
    }

    void Fire()
    {
        if (!Input.GetKey(KeyCode.Space))
            return;

        //���� ������
        if (curShootDelay < maxShootDelay)
            return;

        //����
        if (BulletPool.Instance.CheckPool())
        {
            //CreatBP(�Ѿ˼ӵ�, �Ѿ˻�����ġ, �ӽúθ�, �Ѿ˽�������Ʈ)
            GameObject bullet = BulletPool.Instance.CreateBP(power, speedBullet, transform, parentTemp, sp[power-1]);
        }
        else
        {
            BulletPool.Instance.Play(power, speedBullet, sp[power-1]);
        }

        curShootDelay = 0;
    }

    void Reload()
    {
        curShootDelay += Time.deltaTime;
    }

    void OnHit()
    {
        //�����ð� �߰�

        //life����
        lifeValue--; 
        if (lifeValue < 0)
        {
            Debug.Log("�׾����ϴ�!");
            UiManager.GameOver();
        }
        else
        {
            UiManager.DeleteLifeIcon();
        }
        //�ǰ� ���
        sr.color = new Color(0.75f, 0.75f, 0.75f, 1f);
        Invoke("ReturnColor", 0.2f);
    }
    void ReturnColor()
    {
        sr.color = new Color(1f, 1f, 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�ǰ�
        if (collision.gameObject.tag == "Enemy")
        {
            OnHit();
            Destroy(collision.gameObject);
        }

        //������
        if (collision.gameObject.CompareTag("Item"))
        {
            Item itemObj = collision.gameObject.GetComponent<Consumable>().item;

            if (itemObj != null)
            {
                collision.gameObject.SetActive(false);
                switch (itemObj.itemType)
                {
                    case Item.ItemType.COIN:
                        //money����
                        AdjustCoinPoint(100);
                        break;
                    case Item.ItemType.BOOM:
                        //boom �߻�
                        break;
                    case Item.ItemType.POWER:
                        //PowerUP
                        if (power >= 2)
                            break;
                        power++;
                        break;
                    default:
                        break;
                }
            }
        }
    }
    public void AdjustCoinPoint(int coin)
    {
        moeny += coin;
    }
}
