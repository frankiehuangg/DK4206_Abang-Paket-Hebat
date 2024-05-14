using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneScreen : MonoBehaviour
{
    public GameObject phoneScreen;
    public Building buildingDescription;

    public TextMeshProUGUI tembok;
    public TextMeshProUGUI atap;
    public TextMeshProUGUI jendela;
    public TextMeshProUGUI view;

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
            tembok.text = "Tembok: " + buildingDescription.tembok;
            atap.text = "Atap: " + buildingDescription.atap;
            jendela.text = "Jendela: " + buildingDescription.jendela;
            view.text = "View: " + buildingDescription.view;
        }
        else
        {
            tembok.text = "Tembok: None";
            atap.text = "Atap: None";
            jendela.text = "Jendela: None";
            view.text = "View: None";
        }
    }
}
