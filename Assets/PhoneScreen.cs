using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneScreen : MonoBehaviour
{
    public GameObject phoneScreen;
    public Building buildingDescription;

    public Sprite[] houseRoofSprites;
    public Sprite[] houseBodySprites;
    public Sprite[] houseDirectionSprites;
    public Sprite[] houseDecorationSprites;

    public Image houseRoofImage;
    public Image houseBodyImage;
    public Image houseDirectionImage;
    public Image[] houseDecorationImages;

    private void Update()
    {
        SetScreen();
    }
    public void OpenPhone()
    {
        phoneScreen.SetActive(true);
    }

    public void ClosePhone()
    {
        phoneScreen.SetActive(false);
    }

    public void SetScreen()
    {
        if (buildingDescription != null)
        {
            SetVisible();
            SetRoof();
            SetBody();
            SetDirection();
            SetDecoration();
        }
        else
        {
            SetInvisible();
        }
    }

    private void SetRoof()
    {
        switch (buildingDescription.atap)
        {
            case "Coklat":
                houseRoofImage.sprite = houseRoofSprites[0];
                break;
            case "Kuning":
                houseRoofImage.sprite = houseRoofSprites[1];
                break;
            case "Biru":
                houseRoofImage.sprite = houseRoofSprites[2];
                break;
            case "Oranye":
                houseRoofImage.sprite = houseRoofSprites[3];
                break;
            default:
                break;
        }
    }

    private void SetBody()
    {
        switch (buildingDescription.tembok)
        {
            case "Coklat":
                houseBodyImage.sprite = houseBodySprites[0];
                break;
            case "Kuning":
                houseBodyImage.sprite = houseBodySprites[1];
                break;
            case "Hijau":
                houseBodyImage.sprite = houseBodySprites[2];
                break;
            case "Biru":
                houseBodyImage.sprite = houseBodySprites[3];
                break;
            default:
                break;
        }
    }

    private void SetDirection()
    {
        switch (buildingDescription.view)
        {
            case "Back":
                houseDirectionImage.sprite = houseDirectionSprites[0];
                break;
            case "Front":
                houseDirectionImage.sprite = houseDirectionSprites[1];
                break;
            case "Left":
                houseDirectionImage.sprite = houseDirectionSprites[2];
                break;
            case "Right":
                houseDirectionImage.sprite = houseDirectionSprites[3];
                break;
            default:
                break;
        }
    }

    private void SetDecoration()
    {
        for (int i = 0; i < 3; i++)
        {
            switch (buildingDescription.decorations[i]) 
            {
                case "Pot":
                    houseDecorationImages[i].sprite = houseDecorationSprites[1];
                    break;
                default:
                    houseDecorationImages[i].color = new Color(1f, 1f, 1f, 0f);
                    break;
            }
        }
    }

    private void SetVisible()
    {
        houseRoofImage.color = new Color(1f, 1f, 1f, 1f);
        houseBodyImage.color = new Color(1f, 1f, 1f, 1f);
        houseDirectionImage.color = new Color(1f, 1f, 1f, 1f);
        for (int i = 0; i < 3; i++)
        {
            houseDecorationImages[i].color = new Color(1f, 1f, 1f, 1f);
        }
    }

    private void SetInvisible()
    {
        houseRoofImage.color = new Color(1f, 1f, 1f, 0f);
        houseBodyImage.color = new Color(1f, 1f, 1f, 0f);
        houseDirectionImage.color = new Color(1f, 1f, 1f, 0f);
        for (int i = 0; i < 3;i++)
        {
            houseDecorationImages[i].color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
