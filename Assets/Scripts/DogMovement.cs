using System;
using UnityEngine;
using UnityEngine.AI;

public class DogMovement : MonoBehaviour
{
    public Transform playerTransform;

    public DeliveryManager deliveryManager;

    private NavMeshAgent agent;

    private Animator playerAnimator;
    private Animator animator;
    private NavMeshAgent nav;
    private SpriteRenderer sprite;
    private Vector3 spawnPoint;

    private float playerDistance;

    private float minDistance = 0.5f;

    private bool finishedChasing = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerAnimator = playerTransform.GetComponentInChildren<Animator>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        nav = GetComponent<NavMeshAgent>();
        spawnPoint = transform.position;
    }

    void FixedUpdate() {
        animator.SetBool("isChasing", nav.velocity != Vector3.zero);
    }

    void Update()
    {
        if (finishedChasing)
        {
            if (Vector3.Distance(transform.position, spawnPoint) < minDistance)
            {
                finishedChasing = false;
            }
            else
            {
                agent.destination = spawnPoint;
            }
        }

        if (!finishedChasing)
        {
            playerDistance = Vector3.Distance(transform.position, playerTransform.position);

            if (playerDistance < 20f && deliveryManager.isDelivering)
            {
                agent.destination = playerTransform.position;
            }
            else
            {
                agent.destination = spawnPoint;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            finishedChasing = true;
            if(deliveryManager.isDelivering) deliveryManager.OnStealed();
            playerAnimator.SetBool("isDelivering", false);
        }
    }
}
