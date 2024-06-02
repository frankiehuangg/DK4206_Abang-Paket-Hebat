using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    public Sprite[] sprites;
    public int waitingDuration = 10;
    public int waitingCountdown = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(waitingCountdown <= 0) StartCoroutine(StartWaiting());

        if(waitingCountdown < (float)waitingDuration / 3) {
            SetMad();
        } else if(waitingCountdown < (float)waitingDuration * 2 / 3) {
            SetPoker();
            Debug.Log("a");
        } else {
            SetHappy();
        }
    }

    public void SetSprite(int id) {
        sprite.sprite = sprites[id];
    }

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
