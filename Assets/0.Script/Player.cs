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

    Animator anim;

    [SerializeField] private Transform parentTemp;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
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
            GameObject bullet = BulletPool.Instance.CreateBP(speedBullet, transform, parentTemp, sp[power]);
        }
        BulletPool.Instance.Play(sp[power]);

        curShootDelay = 0;
    }

    void Reload()
    {
        curShootDelay += Time.deltaTime;
    }
}
