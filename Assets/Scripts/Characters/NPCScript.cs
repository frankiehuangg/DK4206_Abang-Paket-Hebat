using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer reaction;
    [SerializeField] private Sprite[] reactions;
    [SerializeField] private Sprite[] npcSprites;
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
        if(waitingCountdown < (float)waitingDuration / 3) {
            SetMad();
        } else if(waitingCountdown < (float)waitingDuration * 2 / 3) {
            SetPoker();
        } else {
            SetHappy();
        }
    }

    public void Wait() {
        if(waitingCountdown <= 0) {
            transform.Find("Thoughts").gameObject.SetActive(true);
            StartCoroutine(StartWaiting());
        }
    }

    public void Receive() {
        transform.Find("Thoughts").gameObject.SetActive(false);
        StopCoroutine(StartWaiting());
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
        reaction.sprite = reactions[0];
    }

    public void SetPoker() {
        reaction.sprite = reactions[1];
    }

    public void SetMad() {
        reaction.sprite = reactions[2];
    }



    IEnumerator StartWaiting () {
        waitingCountdown = waitingDuration;
        while (waitingCountdown > 0) {
            yield return new WaitForSeconds (1);
            waitingCountdown--;
        }
    }
}
