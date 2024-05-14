using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeLeft : Building
{
    public override void SetDescription()
    {
        this.view = "Left";

        switch (this.spriteIndex)
        {
            case 0:
                this.tembok = "Biru";
                this.atap = "Coklat";
                this.jendela = 2;
                break;
            case 1:
                this.tembok = "Hijau";
                this.atap = "Coklat";
                this.jendela = 0;
                break;
            case 2:
                this.tembok = "Putih";
                this.atap = "Oranye";
                this.jendela = 1;
                break;
            case 3:
                this.tembok = "Kuning";
                this.atap = "Oranye";
                this.jendela = 0;
                break;
            case 4:
                this.tembok = "Hijau";
                this.atap = "Putih";
                this.jendela = 2;
                break;
            default:
                break;
        }
    }
}
