using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public string tembok;
    public string atap;
    public string view;
    public string[] decorations;

    public int spriteIndex;

    private void Awake()
    {
        tembok = "None";
        atap = "None";
        view = "None";
        decorations = new string[3];
    }

    public abstract void SetDescription();

}
