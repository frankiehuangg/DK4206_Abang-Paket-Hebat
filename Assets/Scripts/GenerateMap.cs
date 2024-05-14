using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateMap : MonoBehaviour
{
    public GameObject[] frontHomePrefab;
    public GameObject[] backHomePrefab;
    public GameObject[] leftHomePrefab;
    public GameObject[] rightHomePrefab;

    public RandomPackageSpawn packageSpawner;

    private Vector3[] frontHomeLocation = {
        new(-17, 1.5f, -8),
        new(-17, 1.5f, 14),
        new(-15, 1.5f, 3),
        new(-15, 1.5f, -2),
        new(-15, 1.5f, -15),
        new(-12, 1.5f, 9),
        new(-3, 1.5f, 14),
        new(0, 1.5f, -10),
        new(0, 1.5f, 14),
        new(3, 1.5f, 14),
        new(7, 1.5f, -7),
        new(8, 1.5f, -15),
        new(9, 1.5f, 14),
        new(12, 1.5f, -2),
        new(12, 1.5f, 6),
        new(15, 1.5f, 6),
        new(16, 1.5f, -10),
        new(17, 1.5f, 14),
    };
    private Vector3[] backHomeLocation = {
        new(-14, 1.5f, -9),
        new(-11, 1.5f, -9),
        new(-11, 1.5f, 4),
        new(-10, 1.5f, -14),
        new(-7, 1.5f, -5),
        new(-7, 1.5f, 9),
        new(-7, 1.5f, -15),
        new(-5, 1.5f, -2),
        new(-4, 1.5f, 9),
        new(-3, 1.5f, -10),
        new(4, 1.5f, -5),
        new(8, 1.5f, -12),
        new(9, 1.5f, 1),
        new(11, 1.5f, -14),
        new(12, 1.5f, 1),
        new(14, 1.5f, 9),
        new(17, 1.5f, 9),
        new(15, 1.5f, -2),
        new(17, 1.5f, -7),
    };
    private Vector3[] leftHomeLocation = {
        new(-15, 1.5f, 6),
        new(-15, 1.5f, 9),
        new(-10, 1.5f, -4),
        new(-9, 1.5f, 14),
        new(1, 1.5f, -5),
        new(2, 1.5f, -15),
        new(3, 1.5f, -8),
        new(5, 1.5f, 0),
        new(6, 1.5f, 8),
        new(5, 1.5f, -14),
        new(9, 1.5f, -2),
        new(-10, 1.5f, -17),
        new(11, 1.5f, 9),
        new(13, 1.5f, -8),
        new(14, 1.5f, 14),
        new(17, 1.5f, 3),
    };
    private Vector3[] rightHomeLocation = {
        new(-17, 1.5f, -5),
        new(-15, 1.5f, -12),
        new(-14, 1.5f, 14),
        new(-11, 1.5f, 1),
        new(-8, 1.5f, -8),
        new(-5, 1.5f, 3),
        new(-5, 1.5f, 6),
        new(-4, 1.5f, -5),
        new(-3, 1.5f, -13),
        new(-3, 1.5f, -17),
        new(0, 1.5f, 1),
        new(1, 1.5f, 6),
        new(1, 1.5f, 9),
        new(6, 1.5f, 3),
        new(14, 1.5f, -15),
    };

    private Vector3[] destinationLocation =
    {
        new(-17, 1.5f, -8),
        new(-14, 1.5f, -9),
        new(-15, 1.5f, 6),
        new(-17, 1.5f, -5),
    };

    void Start()
    {
        System.Random random = new();
        GameObject temp;

        foreach (Vector3 location in leftHomeLocation)
        {
            temp = Instantiate(frontHomePrefab[random.Next(0, frontHomePrefab.Length)], location, Quaternion.identity);
            if (destinationLocation.Contains<Vector3>(location))
            {
                temp.transform.gameObject.tag = "Destination";
            }
        }
        foreach (Vector3 location in rightHomeLocation)
        {
            temp = Instantiate(backHomePrefab[random.Next(0, backHomePrefab.Length)], location, Quaternion.identity);
            if (destinationLocation.Contains<Vector3>(location))
            {
                temp.transform.gameObject.tag = "Destination";
            }
        }
        foreach (Vector3 location in backHomeLocation)
        {
            temp = Instantiate(leftHomePrefab[random.Next(0, leftHomePrefab.Length)], location, Quaternion.identity);
            if (destinationLocation.Contains<Vector3>(location))
            {
                temp.transform.gameObject.tag = "Destination";
            }
        }
        foreach (Vector3 location in frontHomeLocation)
        {
            temp = Instantiate(rightHomePrefab[random.Next(0, rightHomePrefab.Length)], location, Quaternion.identity);
            if (destinationLocation.Contains<Vector3>(location))
            {
                temp.transform.gameObject.tag = "Destination";
            }
        }

    }

    void Update()
    {

    }
}
