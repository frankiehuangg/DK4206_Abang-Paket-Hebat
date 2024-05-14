using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public string[] spriteDescriptions;
    public string currentSpriteDescription;
    private SpriteRenderer spriteRenderer;
    private Building building;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        building = GetComponent<Building>();

        ChangeSprite();
    }

    void ChangeSprite()
    {
        int index = UnityEngine.Random.Range(0, sprites.Length);

        spriteRenderer.sprite = sprites[index];
        currentSpriteDescription = spriteDescriptions[index];
        building.spriteIndex = index;
        building.SetDescription();
    }
}
