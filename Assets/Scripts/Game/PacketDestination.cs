using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PacketDestination : MonoBehaviour
{
    public Destination[] possibleDestination;
    public Destination destination = null;
    public Delivery delivery;
    // Start is called before the first frame update
    void Start()
    {

        if (possibleDestination == null)
        {
            Debug.Log("No destination");
        }
        else
        {
            destination = RandomizeDestination();
            Debug.Log(destination.buildingStop.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Destination RandomizeDestination()
    {
        return possibleDestination[UnityEngine.Random.Range(0, possibleDestination.Length)];
    }
}
