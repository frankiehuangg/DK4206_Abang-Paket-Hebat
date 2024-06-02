using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Sprite[] npcSprites;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        RandomizeSprite();
    }

    private void RandomizeSprite()
    {
        if (spriteRenderer != null)
        {
            int spriteIndex = UnityEngine.Random.Range(0, npcSprites.Length);
            spriteRenderer.sprite = npcSprites[spriteIndex];
        }
    }

    public void setHappy() {
        animator.SetInteger("mood", 0);
    }

    public void setPoker() {
        animator.SetInteger("mood", 1);
    }

    public void setMad() {
        animator.SetInteger("mood", 2);
    }
}
