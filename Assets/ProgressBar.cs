using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider barFiller;
    public GameObject player;
    public GameObject package;

    public bool isSearching;
    public float initialDistance;
    public float currentDistance;


    private void Awake()
    {
        barFiller = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (package != null)
        {
            if (!isSearching)
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
            isSearching = false;
        }

    }

    private void SetBar()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, 0 , player.transform.position.z);
        Vector3 destinationPosition = new Vector3(package.transform.position.x, 0, package.transform.position.z);

        initialDistance = Vector3.Distance(destinationPosition, playerPosition);

        isSearching = true;
    }

    private void UpdateBar()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        Vector3 destinationPosition = new Vector3(package.transform.position.x, 0, package.transform.position.z);

        currentDistance = Vector3.Distance(destinationPosition, playerPosition);

        if (currentDistance < initialDistance)
        {
            if (currentDistance < 5)
            {
                barFiller.value = 1;
            }
            else
            {
                barFiller.value = 1 - (initialDistance - currentDistance) * 1.1f / initialDistance;
            }
        }
        else
        {
            barFiller.value = 1;
        }
    }
}
