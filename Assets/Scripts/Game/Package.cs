using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    GameObject[] possibleDestination;
    public GameObject destination;
    // Start is called before the first frame update
    void Start()
    {
        possibleDestination = GameObject.FindGameObjectsWithTag("Destination");

        if (possibleDestination == null)
        {
            Debug.Log("No destination");
        }
        else
        {
            destination = RandomizeDestination();
            Debug.Log(destination.name);
        }
    }

    GameObject RandomizeDestination()
    {
        return possibleDestination[UnityEngine.Random.Range(0, possibleDestination.Length)];
    }
}
