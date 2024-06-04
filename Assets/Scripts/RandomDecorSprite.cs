using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreeSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public bool forceEnable = false;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeSprite();
    }

    void ChangeSprite()
    {
        bool useSprite = UnityEngine.Random.Range(0, 100) < 80;

        if (forceEnable || useSprite)
        {
            int index = UnityEngine.Random.Range(0, sprites.Length);
            spriteRenderer.sprite = sprites[index];
        }
        else
        {
            spriteRenderer.sprite = null;
        }

    }
}
