using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
    private List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer sr;

    private UnityAction action = null;
    private UnityAction frameAction = null;

    private float spriteDelayTime;
    private float delayTime = 0f;

    private int spriteAnimationIndex = 0;

    private bool loop = true;
    private int actionIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprites.Count == 0)
            return;

        delayTime += Time.deltaTime;
        if (delayTime > spriteDelayTime)
        {
            delayTime = 0;
            sr.sprite = sprites[spriteAnimationIndex];
            spriteAnimationIndex++;

            if (spriteAnimationIndex > sprites.Count - 1)
            {
                if (action == null)
                {
                    spriteAnimationIndex = 0;
                }
                else
                {
                    sprites.Clear();
                    action();
                    action = null;
                }

                if (!loop)
                {
                    sprites.Clear();
                    sr.sprite = null;
                }
            }

            if (actionIndex == spriteAnimationIndex)
            {
                actionIndex = -1;
                frameAction();
                frameAction = null;
            }
        }
    }

    void Init()
    {
        delayTime = float.MaxValue;
        actionIndex = -1;
        sprites.Clear();
        spriteAnimationIndex = 0;
    }

    public void SetSprite(List<Sprite> argSprites, float delayTime, bool isLoop)
    {
        Init();
        loop = isLoop;
        sprites = argSprites.ToList();
        spriteDelayTime = delayTime;
    }

    public void SetSprite(List<Sprite> argSprites, float delayTime, UnityAction action)
    {
        Init();
        sprites = argSprites.ToList();
        spriteDelayTime = delayTime;
        this.action = action;
    }

    public void SetSprite(List<Sprite> argSprites, float delayTime, UnityAction action, UnityAction frameAction, int actionIndex)
    {
        Init();

        sprites = argSprites.ToList();
        spriteDelayTime = delayTime;

        this.action = action;
        this.frameAction = frameAction;
        this.actionIndex = actionIndex;
    }

    public void SetSprite(List<Sprite> argSprites, float delayTime)
    {
        Init();
        sprites = argSprites.ToList();
        StartCoroutine(ReturnSprite(argSprites, delayTime));
    }

    IEnumerator ReturnSprite(List<Sprite> argSprites, float delayTime)
    {
        yield return new WaitForSeconds(0.01f);
        SetSprite(argSprites, delayTime, true);
    }
}