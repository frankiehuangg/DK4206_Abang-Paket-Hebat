using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeRight : Building
{
    public override void SetDescription()
    {
        this.view = "Right";

        switch (this.spriteIndex)
        {
            case 0:
                this.tembok = "Kuning";
                this.atap = "Oranye";
                break;
            case 1:
                this.tembok = "Putih";
                this.atap = "Biru";
                break;
            case 2:
                this.tembok = "Biru";
                this.atap = "Oranye";
                break;
            case 3:
                this.tembok = "Hijau";
                this.atap = "Oranye";
                break;
            default:
                break;
        }
    }
}
