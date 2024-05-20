using UnityEngine;

public class RenderMap : MonoBehaviour
{
    public GameObject[] HomeCubeFrontPrefab;
    public GameObject[] HomeCubeBackPrefab;
    public GameObject[] HomeCubeLeftPrefab;
    public GameObject[] HomeCubeRightPrefab;

    public GameObject[] HomeBlockFrontPrefab;
    public GameObject[] HomeBlockBackPrefab;
    public GameObject[] HomeBlockLeftPrefab;
    public GameObject[] HomeBlockRightPrefab;

    public GameObject SmallShopFrontPrefab;
    public GameObject SmallShopBackPrefab;
    public GameObject SmallShopLeftPrefab;
    public GameObject SmallShopRightPrefab;

    public GameObject LargeShopFrontPrefab;
    public GameObject LargeShopBackPrefab;
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

        foreach (Vector3 location in MapData.HomeCubeFrontLocations)
        {
            Instantiate(HomeCubeRightPrefab[random.Next(0, HomeCubeRightPrefab.Length)], location, Quaternion.identity);
        }

        foreach (Vector3 location in MapData.HomeCubeBackLocations)
        {
            Instantiate(HomeCubeLeftPrefab[random.Next(0, HomeCubeLeftPrefab.Length)], location, Quaternion.identity);
        }

        foreach (Vector3 location in MapData.HomeCubeLeftLocations)
        {
            Instantiate(HomeCubeFrontPrefab[random.Next(0, HomeCubeFrontPrefab.Length)], location, Quaternion.identity);
        }

        foreach (Vector3 location in MapData.HomeCubeRightLocations)
        {
            Instantiate(HomeCubeBackPrefab[random.Next(0, HomeCubeBackPrefab.Length)], location, Quaternion.identity);
        }
    }
}