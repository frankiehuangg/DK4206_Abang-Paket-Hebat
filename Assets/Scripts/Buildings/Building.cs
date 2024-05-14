using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public string tembok;
    public string atap;
    public int jendela;
    public string view;

    public int spriteIndex;

    private void Awake()
    {
        tembok = "None";
        atap = "None";
        jendela = 0;
        view = "None";
    }

    public abstract void SetDescription();

}
