using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
