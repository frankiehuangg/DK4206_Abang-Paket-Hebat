using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreeSprite : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeSprite();
    }

    void ChangeSprite()
    {
        int index = UnityEngine.Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[index];
    }
}
