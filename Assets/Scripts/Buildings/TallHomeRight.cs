using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallHomeRight : Building
{
    public override void SetDescription()
    {
        this.view = "Right";

        switch (this.spriteIndex)
        {
            case 0:
                this.tembok = "Kuning";
                this.atap = "Oranye";
                this.jendela = 1;
                break;
            default:
                break;
        }
    }
}
