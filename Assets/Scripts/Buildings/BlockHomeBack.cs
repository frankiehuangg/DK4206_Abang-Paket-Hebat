using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHomeBack : Building
{
    public override void SetDescription()
    {
        this.view = "Back";

        switch (this.spriteIndex)
        {
            case 0:
                this.tembok = "Merah";
                this.atap = "Merah";
                break;
            case 1:
                this.tembok = "Oranye";
                this.atap = "Biru";
                break;
            default:
                break;
        }
    }
}
