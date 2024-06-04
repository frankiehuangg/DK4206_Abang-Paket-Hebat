using System.Linq;
using UnityEngine;

public class RenderMap : MonoBehaviour
{
    public GameObject[] HomeCubeFrontPrefab;
    public GameObject[] HomeCubeBackPrefab;
    public GameObject[] HomeCubeLeftPrefab;
    public GameObject[] HomeCubeRightPrefab;

    public GameObject HomeBlockFrontPrefab;
    public GameObject HomeBlockBackPrefab;
    public GameObject HomeBlockLeftPrefab;
    public GameObject HomeBlockRightPrefab;

    public GameObject SmallShopFrontPrefab;
    public GameObject SmallShopBackPrefab;
    public GameObject SmallShopLeftPrefab;
    public GameObject SmallShopRightPrefab;

    public GameObject LargeShopFrontPrefab1;
    public GameObject LargeShopFrontPrefab2;
    public GameObject LargeShopLeftPrefab;
    public GameObject LargeShopRightPrefab;

    void Start()
    {
        System.Random random = new();

        /**
         * L   B
         *
         * F   R
         * 
         * Front -> Right
         * Right -> Back
         * Back -> Left
         * Left -> Front
         */

        GameObject temp;

        foreach (Vector3 location in MapData.HomeCubeFrontLocations)
        {
            temp = Instantiate(HomeCubeRightPrefab[random.Next(0, HomeCubeRightPrefab.Length)], location, Quaternion.identity);
            if (random.Next(0, 3) != 0)
            {
                temp.transform.Find("NPC").gameObject.SetActive(false);
            }
            if (random.Next(0, 4) == 0)
            {
                temp.transform.gameObject.tag = "Destination";
                temp.transform.Find("NPC").gameObject.SetActive(true);
            }
        }

        foreach (Vector3 location in MapData.HomeCubeBackLocations)
        {
            temp = Instantiate(HomeCubeLeftPrefab[random.Next(0, HomeCubeLeftPrefab.Length)], location, Quaternion.identity);
            if (random.Next(0, 3) != 0)
            {
                temp.transform.Find("NPC").gameObject.SetActive(false);
            }
            if (random.Next(0, 4) == 1)
            {
                temp.transform.gameObject.tag = "Destination";
                temp.transform.Find("NPC").gameObject.SetActive(true);
            }
        }

        foreach (Vector3 location in MapData.HomeCubeLeftLocations)
        {
            temp = Instantiate(HomeCubeFrontPrefab[random.Next(0, HomeCubeFrontPrefab.Length)], location, Quaternion.identity);
            if (random.Next(0, 3) != 0)
            {
                temp.transform.Find("NPC").gameObject.SetActive(false);
            }
            if (random.Next(0, 4) == 2)
            {
                temp.transform.gameObject.tag = "Destination";
                temp.transform.Find("NPC").gameObject.SetActive(true);
            }
        }

        foreach (Vector3 location in MapData.HomeCubeRightLocations)
        {
            temp = Instantiate(HomeCubeBackPrefab[random.Next(0, HomeCubeBackPrefab.Length)], location, Quaternion.identity);
            if (random.Next(0, 3) != 0)
            {
                temp.transform.Find("NPC").gameObject.SetActive(false);
            }
            if (random.Next(0, 4) == 3)
            {
                temp.transform.gameObject.tag = "Destination";
                temp.transform.Find("NPC").gameObject.SetActive(true);
            }
        }

        foreach (Vector3 location in MapData.HomeBlockFrontLocations)
        {
            temp = Instantiate(HomeBlockRightPrefab, location, Quaternion.identity);
            if (random.Next(0, 3) != 0)
            {
                temp.transform.Find("NPC").gameObject.SetActive(false);
            }
            if (MapData.destinationLocations.Contains(location))
            {
                temp.transform.gameObject.tag = "Destination";
                temp.transform.Find("NPC").gameObject.SetActive(true);
            }
        }

        foreach (Vector3 location in MapData.HomeBlockBackLocations)
        {
            temp = Instantiate(HomeBlockLeftPrefab, location, Quaternion.identity);
            if (random.Next(0, 3) != 0)
            {
                temp.transform.Find("NPC").gameObject.SetActive(false);
            }
            if (MapData.destinationLocations.Contains(location))
            {
                temp.transform.gameObject.tag = "Destination";
                temp.transform.Find("NPC").gameObject.SetActive(true);
            }
        }

        foreach (Vector3 location in MapData.HomeBlockLeftLocations)
        {
            temp = Instantiate(HomeBlockFrontPrefab, location, Quaternion.identity);
            if (MapData.destinationLocations.Contains(location))
            {
                temp.transform.gameObject.tag = "Destination";
            }
        }

        foreach (Vector3 location in MapData.HomeBlockRightLocations)
        {
            temp = Instantiate(HomeBlockBackPrefab, location, Quaternion.identity);
            if (random.Next(0, 3) != 0)
            {
                temp.transform.Find("NPC").gameObject.SetActive(false);
            }
            if (MapData.destinationLocations.Contains(location))
            {
                temp.transform.gameObject.tag = "Destination";
                temp.transform.Find("NPC").gameObject.SetActive(true);
            }
        }

        // Small Shops
        foreach (Vector3 location in MapData.SmallShopLeftLocations)
        {
            Instantiate(SmallShopFrontPrefab, location, Quaternion.identity);
        }

        foreach (Vector3 location in MapData.SmallShopFrontLocations)
        {
            Instantiate(SmallShopRightPrefab, location, Quaternion.identity);
        }

        // Large Shops
        Instantiate(LargeShopFrontPrefab1, MapData.LargeShopFrontLocation1, Quaternion.identity);
        Instantiate(LargeShopFrontPrefab2, MapData.LargeShopFrontLocation2, Quaternion.identity);
        Instantiate(LargeShopLeftPrefab, MapData.LargeShopLeftLocations, Quaternion.identity);
        Instantiate(LargeShopRightPrefab, MapData.LargeShopRightLocation, Quaternion.identity);
    }
}