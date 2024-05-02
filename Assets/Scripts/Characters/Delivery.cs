using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public bool isDelivering;
    public GameObject destination;
    public RandomPackageSpawn spawner;
    public PlayerMovement playerMovement;

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isStoping)
        {
            CheckOnStop();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (destination != null)
        {
            Debug.Log(collision.gameObject.name);
            if (collision.gameObject.name == destination.name)
            {
                Debug.Log("Arrive");
                spawner.isDelivering = false;
            }
        }
    }

    private void CheckOnStop()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        if (colliders.Length > 0 && destination != null)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.name == destination.name)
                {
                    Debug.Log("Arrive");
                    destination = null;
                    spawner.isDelivering = false;
                    break;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Package"))
        {
            Debug.Log("Found");
            destination = collision.gameObject.GetComponent<Package>().destination;
            Destroy(collision.gameObject);
            spawner.isDelivering = true;
            spawner.isSpawning = false;
        }
    }
}
