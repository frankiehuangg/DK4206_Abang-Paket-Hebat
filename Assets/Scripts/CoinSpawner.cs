using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] coinSpawner;
    public GameObject coin;
    // Start is called before the first frame update
    private void Awake()
    {
        coinSpawner = GameObject.FindGameObjectsWithTag("CoinSpawn");

        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPosition = coinSpawner[Random.Range(0, coinSpawner.Length)].transform.position;
            spawnPosition.y = 1;
            Instantiate(coin, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
