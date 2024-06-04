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

    private int lastRandomIndex;
    private int lastRandomPackage;

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
            int randomIndex = UnityEngine.Random.Range(0, possiblePosition.Length);
            while (randomIndex == lastRandomPackage)
            {
                randomIndex = UnityEngine.Random.Range(0, possiblePosition.Length);
            }
            lastRandomPackage = randomIndex;
            Vector3 spawnPosition = possiblePosition[randomIndex].transform.position;
            spawnPosition.y = 1;
            currentPackage = Instantiate(packagePrefab, spawnPosition, Quaternion.identity);
            isSpawning = true;
            progressBar.package = currentPackage;
        }
        else
        {
            Debug.Log("No spawn point");
        }
    }

    GameObject RandomizeDestination()
    {
        int randomIndex = UnityEngine.Random.Range(0, possibleDestination.Length);
        while (randomIndex == lastRandomIndex)
        {
            randomIndex = UnityEngine.Random.Range(0, possibleDestination.Length);
        }
        lastRandomIndex = randomIndex;
        return possibleDestination[randomIndex];
    }

    private void SetDescriptionOnPhone()
    {
        Building buildingDescription = null;
        if (destination != null)
        {
            buildingDescription = destination.GetComponentInChildren<Building>();
        }

        phone.GetComponent<PhoneScreen>().buildingDescription = buildingDescription;
        phone.GetComponent<PhoneScreen>().SetDefaultBackground();
    }

    private void SetNotificationOnPhone()
    {
        phone.GetComponent<PhoneScreen>().buildingDescription = null;
        phone.GetComponent<PhoneScreen>().SetNotification();
    }

    IEnumerator SetPhoneOnArrive()
    {
        SetNotificationOnPhone();
        yield return new WaitForSeconds(5);
        SetDescriptionOnPhone();
    }

    public void OnArrive()
    {
        destination.transform.Find("Pickup").GetComponent<BoxCollider>().enabled = false;
        destination.transform.Find("Asset").GetComponent<SpriteRenderer>().color = Color.white;
        NPCScript npc = destination.transform.Find("NPC").gameObject.GetComponent<NPCScript>();
        float bonusRate = npc.Receive();
        destination = null;
        StartCoroutine(SetPhoneOnArrive());
        isDelivering = false;

        GameManager.instance.score += 100 + (int) bonusRate * 10;
        GameManager.instance.delivered += 1;
        GameManager.instance.coins += 10;
    }

    public void OnStealed()
    {
        destination.transform.Find("Pickup").GetComponent<BoxCollider>().enabled = false;
        destination.transform.Find("Asset").GetComponent<SpriteRenderer>().color = Color.white;
        NPCScript npc = destination.transform.Find("NPC").gameObject.GetComponent<NPCScript>();
        npc.Stealed();
        destination = null;
        SetDescriptionOnPhone();
        isDelivering = false;
    }

    public void OnFoundPackage()
    {
        destination = RandomizeDestination();
        destination.transform.Find("Pickup").GetComponent<BoxCollider>().enabled = true;
        destination.transform.Find("Asset").GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f);
        NPCScript npc = destination.transform.Find("NPC").gameObject.GetComponent<NPCScript>();
        npc.Wait();
        SetDescriptionOnPhone();
        progressBar.package = null;
        currentPackage = null;

        isDelivering = true;
        isSpawning = false;

        GameManager.instance.picked += 1;
    }
}
