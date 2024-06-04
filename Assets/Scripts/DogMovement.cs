using UnityEngine;
using UnityEngine.AI;

public class DogMovement : MonoBehaviour
{
    public Transform playerTransform;

    public DeliveryManager deliveryManager;

    private Vector3 spawnPoint;

    private NavMeshAgent agent;

    private float playerDistance;

    private float minDistance = 0.5f;

    private bool finishedChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spawnPoint = transform.position;
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
            deliveryManager.isDelivering = false;
        }
    }
}
