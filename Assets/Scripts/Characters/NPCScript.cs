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
    public int waitingDuration = 30;
    public int waitingCountdown = 0;
    public int state = 0;
    bool receiving = false;
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
        if (!receiving) {
            if(waitingCountdown < (float)waitingDuration / 3) {
                SetMad();
            } else if(waitingCountdown < (float)waitingDuration * 2 / 3) {
                SetPoker();
            } else {
                SetHappy();
            }
        }
    }

    public void Wait() {
        if(waitingCountdown <= 0) {
            transform.Find("Thoughts").gameObject.SetActive(true);
            StartCoroutine(StartWaiting());
        }
    }

    public float Receive() {
        StopCoroutine(StartWaiting());
        receiving = true;
        StartCoroutine(StartReceiving());
        if (state == 0)
        {
            return 1f;
        }
        else if (state == 1)
        {
            return 0.5f;
        }
        else
        {
            return 0f;
        }
    }

    public void Stealed() {
        StopCoroutine(StartWaiting());
        receiving = true;
        state = 2;
        StartCoroutine(StartReceiving());
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
        state = 0;
    }

    public void SetPoker() {
        reaction.sprite = reactions[1];
        state = 1;
    }

    public void SetMad() {
        reaction.sprite = reactions[2];
        state = 2;
    }


    IEnumerator StartWaiting () {
        waitingCountdown = waitingDuration;
        while (waitingCountdown > 0) {
            yield return new WaitForSeconds (1);
            waitingCountdown--;
        }
    }

    IEnumerator StartReceiving () {
        reaction.sprite = reactions[state + 3];
        yield return new WaitForSeconds(2);
        transform.Find("Thoughts").gameObject.SetActive(false);
        receiving = false;
    }
}
