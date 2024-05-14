using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBack : Building
{
    public override void SetDescription()
    {
        this.view = "Back";

        switch (this.spriteIndex)
        {
            case 0:
                this.tembok = "Kuning";
                this.atap = "Coklat";
                this.jendela = 1;
                break;
            case 1:
                this.tembok = "Putih";
                this.atap = "Coklat";
                this.jendela = 1;
                break;
            case 2:
                this.tembok = "Merah";
                this.atap = "Oranye";
                this.jendela = 0;
                break;
            case 3:
                this.tembok = "Oranye";
                this.atap = "Biru";
                this.jendela = 1;
                break;
            case 4:
                this.tembok = "Abu-abu";
                this.atap = "Oranye";
                this.jendela = 0;
                break;
            default:
                break;
        }
    }
}
