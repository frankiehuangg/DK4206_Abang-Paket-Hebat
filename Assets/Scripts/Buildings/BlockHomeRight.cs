using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHomeRight : Building
{
    public override void SetDescription()
    {
        this.view = "Right";

        switch (this.spriteIndex)
        {
            case 0:
                this.tembok = "Citrus";
                this.atap = "Hijau";
                break;
            case 1:
                this.tembok = "Pink";
                this.atap = "Merah";
                break;
            case 2:
                this.tembok = "Biru";
                this.atap = "Oranye";
                break;
            case 3:
                this.tembok = "Ungu";
                this.atap = "Oranye";
                break;
            case 4:
                this.tembok = "Krem";
                this.atap = "Biru";
                break;
            default:
                break;
        }
    }
}
