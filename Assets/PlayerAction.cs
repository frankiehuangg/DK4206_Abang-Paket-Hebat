using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject destination;
    public PlayerMovement playerMovement;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (playerMovement.isStoping)
        {
            CheckOnStop();
        }
    }
    private void CheckOnStop()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        if (colliders.Length > 0 && destination != null)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.transform.parent != null && collider.transform.parent.gameObject == destination)
                {
                    animator.SetBool("isDelivering", false);
                    destination = null;
                    DeliveryManager.instance.OnArrive();
                    break;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Package"))
        {
            animator.SetBool("isDelivering", true);
            DeliveryManager.instance.OnFoundPackage();
            Destroy(collision.gameObject);
            
            destination = DeliveryManager.instance.destination;
        }
        
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameManager.instance.coins += 1;
            Destroy(collision.gameObject);
        }
    }
}
