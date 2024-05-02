using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomPackageSpawn : MonoBehaviour
{
    public GameObject packagePrefab;
    public GameObject[] possiblePosition;

    public bool isDelivering = false;
    public bool isSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        possiblePosition = GameObject.FindGameObjectsWithTag("PackageSpawn");
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDelivering && !isSpawning)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        if (possiblePosition != null)
        {
            Vector3 spawnPosition = possiblePosition[UnityEngine.Random.Range(0, possiblePosition.Length)].transform.position;
            spawnPosition.y = 1;
            Instantiate(packagePrefab, spawnPosition, Quaternion.identity);
            isSpawning = true;
        }
        else
        {
            Debug.Log("No spawn point");
        }
    }
}
