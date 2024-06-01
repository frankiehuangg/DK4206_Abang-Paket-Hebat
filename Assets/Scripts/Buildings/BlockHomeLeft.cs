using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHomeLeft : Building
{
    public override void SetDescription()
    {
        this.view = "Left";

        switch (this.spriteIndex)
        {
            case 0:
                this.tembok = "Krem";
                this.atap = "Coklat";
                break;
            case 1:
                this.tembok = "Hijau";
                this.atap = "Oranye";
                break;
            case 2:
                this.tembok = "Krem";
                this.atap = "Hijau";
                break;
            case 3:
                this.tembok = "Pink";
                this.atap = "Biru";
                break;
            case 4:
                this.tembok = "Merah";
                this.atap = "Biru";
                break;
            default:
                break;
        }
    }
}
