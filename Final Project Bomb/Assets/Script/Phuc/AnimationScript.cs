using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int countFrame = 0;

    public float animationTime = 0.5f;
    public Sprite idleSprite;
    public Sprite[] animationSprites;

    public bool loop = true;
    public bool idle = true;

    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() 
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable() 
    {
        spriteRenderer.enabled = false;
    }

    private void Start() 
    {
        InvokeRepeating("TakeFrame", animationTime, animationTime);
    }
    
    private void TakeFrame()
    {
        countFrame += 1;
        if (loop == true && countFrame >= animationSprites.Length)
        {
            countFrame = 0;
        }

        if (idle == true) 
        {
            spriteRenderer.sprite = idleSprite;
        } else if (animationSprites.Length >= 0 && countFrame < animationSprites.Length) 
        {
            spriteRenderer.sprite = animationSprites[countFrame];
        }
    }
}
