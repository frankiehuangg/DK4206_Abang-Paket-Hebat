using System;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float defaultSpeed = 50f;

    private Rigidbody playerRigidbody;
    private Vector3 startPosition;
    private Vector3 endPosition;
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
        if (!hasInput)
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

                Vector3 targetPosition = transform.position + Vector3.right * 100;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);
            }
            else if (endPosition.y > startPosition.y && endPosition.x < startPosition.x && branch.T)
            {
                animator.SetBool("isMoving", true);
                animator.SetInteger("rLTB", 3);

                Vector3 targetPosition = transform.position + Vector3.forward * 100;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);
            }
            else if (endPosition.y < startPosition.y && endPosition.x > startPosition.x && branch.B)
            {
                animator.SetBool("isMoving", true);
                animator.SetInteger("rLTB", 0);

                Vector3 targetPosition = transform.position + Vector3.back * 100;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);
            }
            else if (endPosition.y < startPosition.y && endPosition.x < startPosition.x && branch.L)
            {
                animator.SetBool("isMoving", true);
                animator.SetInteger("rLTB", 1);

                Vector3 targetPosition = transform.position + Vector3.left * 100;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);
            }
            else
            {
                hasInput = false;
            }
        }
        else
        {
            playerRigidbody.velocity = Vector3.zero;
            if (isStoping)
            {
                transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
                isStoping = false;
                animator.SetBool("isMoving", false);
            }
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