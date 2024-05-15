using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallHomeFront : Building
{
    public override void SetDescription()
    {
        this.view = "Front";

        switch (this.spriteIndex)
        {
            case 0:
                this.tembok = "Pink";
                this.atap = "Oranye";
                this.jendela = 2;
                break;
            default:
                break;
        }
    }
}
