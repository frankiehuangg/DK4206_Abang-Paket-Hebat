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
    public float stopingConstraint = 1.2f;
    private Vector3 targetPosition;
    [SerializeField] private BranchScript branch;
    [SerializeField] private Animator animator;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        branch = GetComponent<BranchScript>();
        currentSpeed = defaultSpeed;
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (!hasInput){
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
        if (isStoping)
        {
            if ((transform.position - targetPosition).magnitude <= stopingConstraint)
            {
                hasInput = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (hasInput)
        {
            if (endPosition.y > startPosition.y && endPosition.x > startPosition.x && branch.R)
            {
                animator.SetBool("isMoving", true);
                animator.SetInteger("rLTB", 2);
                playerRigidbody.velocity = new Vector3(currentSpeed, 0, 0);
            }
            else if (endPosition.y > startPosition.y && endPosition.x < startPosition.x && branch.T)
            {
                animator.SetBool("isMoving", true);
                animator.SetInteger("rLTB", 3);
                playerRigidbody.velocity = new Vector3(0, 0, currentSpeed);
            }
            else if (endPosition.y < startPosition.y && endPosition.x > startPosition.x && branch.B)
            {
                animator.SetBool("isMoving", true);
                animator.SetInteger("rLTB", 0);
                playerRigidbody.velocity = new Vector3(0, 0, -currentSpeed);
            }
            else if (endPosition.y < startPosition.y && endPosition.x < startPosition.x && branch.L)
            {
                playerRigidbody.velocity = new Vector3(-currentSpeed, 0, 0);
                animator.SetBool("isMoving", true);
                animator.SetInteger("rLTB", 1);
            }
        } else
        {
            playerRigidbody.velocity = Vector3.zero;
            if (isStoping)
            {
                transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
                isStoping = false;
                animator.SetBool("isMoving", false);
            }
        }

        if (playerRigidbody.velocity.magnitude < minForceMagnitude)
        {
            playerRigidbody.velocity = Vector3.zero;
            hasInput = false;
            animator.SetBool("isMoving", false);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Branch"))
        {
            branch = col.gameObject.GetComponent<BranchScript>();
            targetPosition = col.gameObject.transform.position;
            isStoping = true;
        }
    }

}