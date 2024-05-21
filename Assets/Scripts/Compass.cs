using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public bool isPlaying = false;
    public float rotationAngle = 0;
    public Image compass;

    public GameObject player;
    public GameObject currentObject;

    public Vector3 playerPosition;
    public Vector3 objectPosition;

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            SetCompassAngle();
        }
    }

    private void SetCompassAngle()
    {
        if (currentObject != null)
        {
            playerPosition = player.transform.position;
            objectPosition = currentObject.transform.position;

            Vector3 direction = (new Vector3(playerPosition.x, 0, playerPosition.z) - new Vector3(objectPosition.x, 0, objectPosition.z)).normalized;
            rotationAngle = (Vector3.SignedAngle(new Vector3(1, 0, 1), direction, Vector3.up) * -1) + 130;
        }
        else
        {
            rotationAngle = 0;
        }
        compass.transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
