using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHomeFront : Building
{
    public override void SetDescription()
    {
        this.view = "Front";

        switch (this.spriteIndex)
        {
            case 0:
                this.tembok = "Kuning";
                this.atap = "Ungu";
                break;
            case 1:
                this.tembok = "Putih";
                this.atap = "Ungu";
                break;
            case 2:
                this.tembok = "Putih";
                this.atap = "Oranye";
                break;
            case 3:
                this.tembok = "Merah";
                this.atap = "Biru";
                break;
            case 4:
                this.tembok = "Krem";
                this.atap = "Hijau";
                break;
            default:
                break;
        }
    }
}
