using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUpSpawner : MonoBehaviour
{
    public GameObject[] timeUpSpawner;
    public GameObject timeUp;
    Vector3 prevPosition;
    bool isAlive = false;
    // Start is called before the first frame update
    private void Awake()
    {
        timeUpSpawner = GameObject.FindGameObjectsWithTag("TimeUpSpawn");
    }

    void Update() {
        if(!isAlive) {
            StartCoroutine(Spawn());
        }
    }

    // Update is called once per frame
    IEnumerator Spawn()
    {
        isAlive = true;
        Vector3 spawnPosition = timeUpSpawner[Random.Range(0, timeUpSpawner.Length)].transform.position;
        prevPosition = spawnPosition;
        spawnPosition.y = 1;
        GameObject timeUpObj = Instantiate(timeUp, spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds (5);
        Destroy(timeUpObj);
        isAlive = false;
    }
}
