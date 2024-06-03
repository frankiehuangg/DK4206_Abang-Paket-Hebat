using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUpSpawner : MonoBehaviour
{
    public GameObject[] timeUpSpawner;
    public GameObject timeUp;
    int prevIdx;
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
        int idx = Random.Range(0, timeUpSpawner.Length);
        if (prevIdx == idx) {
            idx =  (idx + 1) % timeUpSpawner.Length;
        }
        prevIdx = idx;
        Vector3 spawnPosition = timeUpSpawner[idx].transform.position;
        spawnPosition.y = 1;
        GameObject timeUpObj = Instantiate(timeUp, spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds (5);
        Destroy(timeUpObj);
        isAlive = false;
    }
}
