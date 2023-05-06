using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum dir
    {
        center, left, right
    }

    public float speed = 5;
    float screen_left = -3f, screen_right = 3f;
    float screen_bottom = -5.3f, screen_top = 5f;

    [SerializeField] private Sprite[] sprites;
    public SpriteRenderer sr;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        sr = transform.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //방향키 무빙
        float x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float clampX = Mathf.Clamp(transform.position.x + x, screen_left, screen_right);
        float y = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        float clampY = Mathf.Clamp(transform.position.y + y, screen_bottom, screen_top);

        transform.position = new Vector2(clampX, clampY);

        //방향에 따른 이미지 변경(feat.Animator)
        if (Input.GetButtonDown("Horizontal") ||
            Input.GetButtonUp("Horizontal"))
        {
            anim.SetInteger("Input", (int)Input.GetAxisRaw("Horizontal"));
        }
    }
}
