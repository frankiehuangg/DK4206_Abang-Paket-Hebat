using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider barFiller;
    public GameObject player;
    public GameObject destination;

    public bool isDelivering;
    public float initialDistance;
    public float currentDistance;


    private void Awake()
    {
        barFiller = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destination != null)
        {
            if (!isDelivering)
            {
                SetBar();
            }
            else
            {
                UpdateBar();
            }
        }
        else
        {
            isDelivering = false;
        }

    }

    private void SetBar()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, 0 , player.transform.position.z);
        Vector3 destinationPosition = new Vector3(destination.transform.position.x, 0, destination.transform.position.z);

        initialDistance = Vector3.Distance(destinationPosition, playerPosition);

        isDelivering = true;
    }

    private void UpdateBar()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        Vector3 destinationPosition = new Vector3(destination.transform.position.x, 0, destination.transform.position.z);

        currentDistance = Vector3.Distance(destinationPosition, playerPosition);

        if (currentDistance < initialDistance)
        {
            if (currentDistance < 5)
            {
                barFiller.value = 1;
            }
            else
            {
                barFiller.value = (initialDistance - currentDistance) * 1.1f / initialDistance;
            }
        }
        else
        {
            barFiller.value = 0;
        }
    }
}
