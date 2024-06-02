using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;

    public CameraFollow cameraWorld;
    public PlayerMovement playerMovement;
    public int zoomOut {get; private set; } = 3;
    public int zoomOutCountdown {get; private set; } = 0;
    public int speedUp {get; private set; } = 3;
    public int speedUpCountdown {get; private set; } = 0;
    private float baseSpeed;
    
    [SerializeField]
    int zoomOutDuration;
    [SerializeField]
    int speedUpDuration;

    private void Awake()
    {
        baseSpeed = playerMovement.defaultSpeed;
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (zoomOutCountdown > 0) {
            cameraWorld.GetComponent<Camera>().orthographicSize = 6.0f;
        } else {
            cameraWorld.GetComponent<Camera>().orthographicSize = 4.0f;
        }

        if (speedUpCountdown > 0) {
            playerMovement.currentSpeed = baseSpeed * 2.5f;
        } else {
            playerMovement.currentSpeed = baseSpeed;
        }
    }

    public void ActivateZoomOut() {
        if (zoomOutCountdown <= 0 && zoomOut > 0) {
            zoomOut--;
            StartCoroutine(ZoomOutActive());
        }
    }

    IEnumerator ZoomOutActive () {
        zoomOutCountdown = zoomOutDuration;
        while (zoomOutCountdown > 0) {
            yield return new WaitForSeconds (1);
            zoomOutCountdown--;
        }
    }

    public void ActivateSpeedUp() {
        if (speedUpCountdown <= 0 && speedUp > 0) {
            speedUp--;
            StartCoroutine(SpeedUpActive());
        }
    }

    IEnumerator SpeedUpActive () {
        speedUpCountdown = speedUpDuration;
        while (speedUpCountdown > 0) {
            yield return new WaitForSeconds (1);
            speedUpCountdown--;
        }
    }
}
