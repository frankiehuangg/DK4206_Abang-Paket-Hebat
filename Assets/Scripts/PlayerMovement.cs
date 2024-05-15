using System;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float defaultSpeed = 20f;

    private float minForceMagnitude = 0.1f;

    private Rigidbody playerRigidbody;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 movement;
    private float currentSpeed;
    private bool hasInput = false;
    public bool isStoping = true;
    private Vector3 targetPosition;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        currentSpeed = defaultSpeed;
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endPosition = Input.GetTouch(0).position;
            hasInput = true;
        }
    }

    private void FixedUpdate()
    {
        if (hasInput)
        {
            if (endPosition.y > startPosition.y && endPosition.x > startPosition.x)
            {
                playerRigidbody.velocity = new Vector3(-currentSpeed, 0, 0);
            }
            else if (endPosition.y > startPosition.y && endPosition.x < startPosition.x)
            {
                playerRigidbody.velocity = new Vector3(0, 0, -currentSpeed);
            }
            else if (endPosition.y < startPosition.y && endPosition.x > startPosition.x)
            {
                playerRigidbody.velocity = new Vector3(0, 0, currentSpeed);
            }
            else if (endPosition.y < startPosition.y && endPosition.x < startPosition.x)
            {
                playerRigidbody.velocity = new Vector3(currentSpeed, 0, 0);
            }
        }

        if (playerRigidbody.velocity.magnitude < minForceMagnitude)
        {
            playerRigidbody.velocity = Vector3.zero;
            hasInput = false;
        }

        else if (isStoping)
        {
            if ((transform.position - targetPosition).magnitude <= .1f)
            {
                hasInput = false;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Branch"))
        {
            targetPosition = col.gameObject.transform.position;
            isStoping = true;
        }
    }

}