using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidBody;

    private Vector3 playerStartPosition;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool hasInput = false;
    public bool isStoping = false;
    private readonly float movementCheckDistance = 1.5f;
    private readonly float collisionCheckDistance = 1f;
    private readonly float playerSpeed = 15f;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasInput) {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
                startTouchPosition = Input.GetTouch(0).position;
                Debug.Log("START\t: " + startTouchPosition.x + " " + startTouchPosition.y);
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
                endTouchPosition = Input.GetTouch(0).position;
                Debug.Log("END\t\t: " + endTouchPosition.x + " " + endTouchPosition.y);
                playerStartPosition = transform.position;
                hasInput = true;
            }
        } else if (isStoping){
            if((transform.position - targetPosition).magnitude <= .1f) {
                hasInput = false;
            }
        }
    }

    private void FixedUpdate() {
        if (hasInput) {
            if (endTouchPosition.y > startTouchPosition.y && endTouchPosition.x > startTouchPosition.x) {
                // Debug.Log("Moving South West");
                
                if (CheckCollision(Vector3.left) && CheckMovement(Vector3.forward, Vector3.back)) {
                    MoveSouthWest();
                    // Debug.Log("Moved player: " + transform.position);
                } else {
                    hasInput = false;
                    rigidBody.velocity = Vector3.zero;
                    // Debug.Log("Collision detected in South West");
                }
            }
            else if (endTouchPosition.y > startTouchPosition.y && endTouchPosition.x < startTouchPosition.x) {
                // Debug.Log("Moving South East");
                
                if (CheckCollision(Vector3.back) && CheckMovement(Vector3.left, Vector3.right)) {
                    MoveSouthEast();
                    // Debug.Log("Moved player: " + transform.position);
                } else {
                    hasInput = false;
                    rigidBody.velocity = Vector3.zero;
                    // Debug.Log("Collision detected in South East");
                }
            }
            else if (endTouchPosition.y < startTouchPosition.y && endTouchPosition.x > startTouchPosition.x) {
                // Debug.Log("Moving North West");
                
                if (CheckCollision(Vector3.forward) && CheckMovement(Vector3.left, Vector3.right)) {
                    MoveNorthWest();
                    // Debug.Log("Moved player: " + transform.position);
                } else {
                    hasInput = false;
                    rigidBody.velocity = Vector3.zero;
                    // Debug.Log("Collision detected in North West");
                }
            }
            else if (endTouchPosition.y < startTouchPosition.y && endTouchPosition.x < startTouchPosition.x) {
                // Debug.Log("Moving North East");

                if (CheckCollision(Vector3.right) && CheckMovement(Vector3.forward, Vector3.back)) {
                    MoveNorthEast();
                    // Debug.Log("Moved player: " + transform.position);
                } else {
                    hasInput = false;
                    rigidBody.velocity = Vector3.zero;
                    // Debug.Log("Collision detected in North East");
                }
            }
        } else {
            rigidBody.velocity = Vector3.zero;
            if(isStoping) {
                transform.position = targetPosition;
                isStoping = false;
            }
        }
    }

    private bool CheckCollision(Vector3 direction) {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, collisionCheckDistance)) {
            if (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("Building")) {
                return false;
            }
        }

        return true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Branch")) {
            targetPosition = col.gameObject.transform.position;
            isStoping = true;
        }
    }

    private bool CheckMovement(Vector3 directionOne, Vector3 directionTwo) {
        // Check if player has move at least 1 distance, keep moving if not
        if ((transform.position - playerStartPosition).magnitude <= 1) {
            return true;
        }

        // Check if current position is divisible by 0.5 but not 1.0, keep moving if not
        if ((transform.position.x % 0.5f != 0f && transform.position.x % 1.0f != 0f) ||   
            (transform.position.z % 0.5f != 0f && transform.position.z % 1.0f != 0f)) {
            return true;
        }

        RaycastHit hitOne, hitTwo;

        if (
            Physics.Raycast(transform.position, directionOne, out hitOne, movementCheckDistance) && 
            Physics.Raycast(transform.position, directionTwo, out hitTwo, movementCheckDistance)) {   
            if (
                hitOne.collider.CompareTag("Wall") || hitOne.collider.CompareTag("Building") && 
                hitTwo.collider.CompareTag("Wall") || hitTwo.collider.CompareTag("Building")) {
                return true;
            }
        }

        return false;
    }

    private void MoveNorthWest() {
        rigidBody.velocity = new Vector3(0, 0, playerSpeed);
    }

    private void MoveSouthEast() {
        rigidBody.velocity = new Vector3(0, 0, -playerSpeed);
    }

    private void MoveNorthEast() {
        rigidBody.velocity = new Vector3(playerSpeed, 0, 0);
    }

    private void MoveSouthWest() {
        rigidBody.velocity = new Vector3(-playerSpeed, 0, 0);
    }
}

// F     R
//
// L     B