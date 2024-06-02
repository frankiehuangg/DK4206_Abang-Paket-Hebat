using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapData
{
    public static Vector3[] HomeCubeFrontLocations = {
        new(-30f, 1.5f, -17f),
        new(-26f, 2f, -25f),
        new(-23f, 2f, 18f),
        new(-22f, 2f, -25f),
        new(-16f, 2f, 16f),
        new(-12f, 2f, 16f),
        new(-8f, 2f, 16f),
        new(-7f, 2f, -13f),
        new(-1f, 2f, 32f),
        new(5f, 2f, -20f),
        new(9f, 2f, -20f),
        new(14f, 2f, 32f),
        new(17f, 2f, 8f),
        new(21f, 2f, 8f),
        new(21f, 2f, 38f),
        new(21f, 2f, 32f),
        new(22f, 2f, -17f),
        new(26f, 2f, -17f),
        new(28f, 2f, 28f),
        new(28f, 2f, 38f),
        new(30f, 2f, -17f),
    };

    public static Vector3[] HomeCubeBackLocations = {
        new(-24f, 2f, -8f),
        new(-20f, 2f, -8f),
        new(-16f, 2f, -28f),
        new(-16f, 2f, 30f),
        new(-15f, 2f, -38f),
        new(-15f, 2f, -34f),
        new(-12f, 2f, -28f),
        new(-10f, 2f, 30f),
        new(-8f, 2f, -28f),
        new(-6f, 2f, 30f),
        new(-3f, 2f, -15f),
        new(0f, 2f, -8f),
        new(1f, 2f, -21f),
        new(1f, 2f, 25f),
        new(4f, 2f, -8f),
        new(5f, 2f, -26f),
        new(5f, 2f, 25f),
        new(9f, 2f, -26f),
        new(15f, 2f, -24f),
        new(16f, 2f, -8f),
        new(17f, 2f, 12f),
        new(19f, 2f, -24f),
        new(23f, 2f, -24f),
        new(27f, 2f, -24f),
    };

    public static Vector3[] HomeCubeLeftLocations = {
        new(-30f, 2f, -38f),
        new(-30f, 2f, -34f),
        new(-24f, 2f, -15f),
        new(-23f, 2f, -38f),
        new(-23f, 2f, 34f),
        new(-23f, 2f, 38f),
        new(-16f, 2f, 20f),
        new(-16f, 2f, 26f),
        new(-13f, 2f, -13f),
        new(1f, 2f, 19f),
        new(4f, 2f, -16f),
        new(4f, 2f, -12f),
        new(5f, 2f, 19f),
        new(8f, 2f, -38f),
        new(12f, 2f, 14f),
        new(22f, 2f, -13f),
        new(28f, 2f, 8f),
        new(28f, 2f, 12f),
        new(28f, 2f, 32f),
    };
    public static Vector3[] HomeCubeRightLocations = {
        new(-30f, 2f, -28f),
        new(-30f, 2f, -24f),
        new(-30f, 2f, -13f),
        new(-30f, 2f, 30f),
        new(-30f, 2f, 34f),
        new(-30f, 2f, 38f),
        new(-23f, 2f, 22f),
        new(-23f, 2f, 26f),
        new(-20f, 2f, -15f),
        new(-8f, 2f, -38f),
        new(-2f, 2f, -38f),
        new(-1f, 2f, 38f),
        new(2f, 2f, -38f),
        new(5f, 2f, 8f),
        new(5f, 2f, 12f),
        new(12f, 2f, 19f),
        new(13f, 2f, -38f),
        new(13f, 2f, -34f),
        new(13f, 2f, -30f),
        new(14f, 2f, 36f),
        new(21f, 2f, 12f),
        new(27f, 2f, -36f),
        new(27f, 2f, -32f),
        new(27f, 2f, -28f),
        new(27f, 2f, 18f),
        new(27f, 2f, 22f),
    };

    public static Vector3[] HomeBlockFrontLocations = {
        new(-15f, 1.5f, 37.5f),
        new(-9f, 1.5f, 37.5f),
        new(0f, 1.5f, 8.5f),
        new(7f, 1.5f, -32.5f),
    };

    public static Vector3[] HomeBlockBackLocations = {
        new(-29f, 1.5f, -8.5f),
        new(-15f, 1.5f, 8.5f),
        new(-8f, 1.5f, -8.5f),
        new(21f, 1.5f, -8.5f),
        new(22f, 1.5f, 24.5f)
    };

    public static Vector3[] HomeBlockLeftLocations = {
        new(-22.5f, 1.5f, -33f),
        new(-3.5f, 1.5f, -20f),
        new(-0.5f, 1.5f, 14f),
        new(8.5f, 1.5f, -33f),
        new(20.5f, 1.5f, -37f),
        new(20.5f, 1.5f, -31f),
    };

    public static Vector3[] HomeBlockRightLocations = {
        new(-29.5f, 1.5f, 24f),
        new(-8.5f, 1.5f, -33f),
        new(8.5f, 1.5f, -15f),
        new(11.5f, 1.5f, 24f),
    };

    public static Vector3[] SmallShopFrontLocations = {
        new(-29f, 1.5f, 18.5f),
        new(0f, 1.5f, -25.5f),
        new(17f, 1.5f, -16.5f),
    };

    public static Vector3[] SmallShopBackLocations = {
        new(-9f, 1.5f, 8.5f),
    };

    public static Vector3[] SmallShopLeftLocations = {
        new(12.5f, 1.5f, 9f),
    };

    public static Vector3[] SmallShopRightLocations = {
        new(8.5f, 1.5f, -9f),
    };

    public static Vector3 LargeShopFrontLocation1 = new(-12f, 4f, -19f);


    public static Vector3 LargeShopFrontLocation2 = new(28f, 4f, -10f);

    public static Vector3 LargeShopLeftLocations = new(-25f, 4f, 10f);

    public static Vector3 LargeShopRightLocation = new(-8f, 4f, 24f);

    public static Vector3[] destinationLocations = {
        new(-8f, 1.5f, 16f),
        new(28f, 1.5f, 28f),
        new(-20f, 1.5f, -8f),
        new(1f, 1.5f, 25f),
        new(4f, 1.5f, -12f),
        new(-30f, 1.5f, -13f),
        new(27f, 1.5f, 22f),
    };
}
