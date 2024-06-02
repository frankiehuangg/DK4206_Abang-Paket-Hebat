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
    public int waitingDuration = 10;
    public int waitingCountdown = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        RandomizeSprite();
    }

    void Update()
    {
        if(waitingCountdown <= 0) StartCoroutine(StartWaiting());

        if(waitingCountdown < (float)waitingDuration / 3) {
            SetMad();
        } else if(waitingCountdown < (float)waitingDuration * 2 / 3) {
            SetPoker();
        } else {
            SetHappy();
        }
    }
    private void RandomizeSprite()
    {
        if (spriteRenderer != null)
        {
            int spriteIndex = UnityEngine.Random.Range(0, npcSprites.Length);
            spriteRenderer.sprite = npcSprites[spriteIndex];
        }
    }


    // Update is called once per frame

    public void SetHappy() {
        animator.SetInteger("mood", 0);
    }

    public void SetPoker() {
        animator.SetInteger("mood", 1);
    }

    public void SetMad() {
        animator.SetInteger("mood", 2);
    }



    IEnumerator StartWaiting () {
        waitingCountdown = waitingDuration;
        while (waitingCountdown > 0) {
            yield return new WaitForSeconds (1);
            waitingCountdown--;
        }
    }
}
