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
                this.jendela = 1;
                break;
            case 1:
                this.tembok = "Putih";
                this.atap = "Biru";
                this.jendela = 2;
                break;
            case 2:
                this.tembok = "Biru";
                this.atap = "Oranye";
                this.jendela = 1;
                break;
            case 3:
                this.tembok = "Hijau";
                this.atap = "Oranye";
                this.jendela = 1;
                break;
            default:
                break;
        }
    }
}
