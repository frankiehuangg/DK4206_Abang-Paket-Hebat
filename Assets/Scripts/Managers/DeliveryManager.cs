using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager instance;

    public GameObject packagePrefab;
    public GameObject[] possiblePosition;
    public GameObject[] possibleDestination;

    public bool isDelivering = false;
    public bool isSpawning = false;
    public bool isPlaying = false;

    public GameObject destination;
    public PlayerMovement playerMovement;
    public GameObject phone;
    public GameObject currentPackage;
    public Compass compass;
    public ProgressBar progressBar;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            possiblePosition = GameObject.FindGameObjectsWithTag("PackageSpawn");
            possibleDestination = GameObject.FindGameObjectsWithTag("Destination");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (possibleDestination == null || possibleDestination.Length == 0) 
        {
            possibleDestination = GameObject.FindGameObjectsWithTag("Destination");
        }

        if (isPlaying)
        {
            if (!isDelivering && !isSpawning)
            {
                Spawn();
            }
            if (isDelivering)
            {
                compass.currentObject = destination;
            }
            if (isSpawning)
            {
                compass.currentObject = currentPackage;
            }
        }
    }

    public void GameStart()
    {
        isPlaying = true;
        compass.isPlaying = true;
        Spawn();
    }

    public void GameOver()
    {
        isPlaying = false;
        compass.isPlaying = false;
        if (currentPackage != null)
        {
            Destroy(currentPackage);
        }
    }

    private void Spawn()
    {
        if (possiblePosition != null)
        {
            Vector3 spawnPosition = possiblePosition[UnityEngine.Random.Range(0, possiblePosition.Length)].transform.position;
            spawnPosition.y = 1;
            currentPackage = Instantiate(packagePrefab, spawnPosition, Quaternion.identity);
            isSpawning = true;
        }
        else
        {
            Debug.Log("No spawn point");
        }
    }

    GameObject RandomizeDestination()
    {
        return possibleDestination[UnityEngine.Random.Range(0, possibleDestination.Length)];
    }

    private void SetDescriptionOnPhone()
    {
        Building buildingDescription = null;
        if (destination != null)
        {
            buildingDescription = destination.GetComponentInChildren<Building>();
        }

        phone.GetComponent<PhoneScreen>().buildingDescription = buildingDescription;
        phone.GetComponent<PhoneScreen>().SetScreen();
    }

    public void OnArrive()
    {
        destination = null;
        SetDescriptionOnPhone();
        progressBar.destination = null;
        isDelivering = false;

        GameManager.instance.score += 100;
        GameManager.instance.delivered += 1;
    }

    public void OnFoundPackage()
    {
        destination = RandomizeDestination();
        SetDescriptionOnPhone();
        progressBar.destination = destination;
        currentPackage = null;

        isDelivering = true;
        isSpawning = false;
    }
}
