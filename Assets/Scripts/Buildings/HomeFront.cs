using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeFront : Building
{
    public override void SetDescription()
    {
        this.view = "Front";

        switch (this.spriteIndex)
        {
            case 0:
                this.tembok = "Pink";
                this.atap = "Kuning";
                this.decorations[0] = "Pot";
                break;
            case 1:
                this.tembok = "Biru";
                this.atap = "Oranye";
                this.decorations[0] = "Pot";
                break;
            case 2:
                this.tembok = "Kuning";
                this.atap = "Biru";
                break;
            case 3:
                this.tembok = "Merah";
                this.atap = "Oranye";
                break;
            default:
                break;
        }
    }
}
