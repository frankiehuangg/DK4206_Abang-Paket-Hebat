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
                this.atap = "AbuGelap";
                this.decorations[0] = "Tanaman";
                break;
            case 1:
                this.tembok = "Putih";
                this.atap = "AbuGelap";
                this.decorations[0] = "Tanaman";
                break;
            case 2:
                this.tembok = "Merah";
                this.atap = "Oranye";
                break;
            case 3:
                this.tembok = "Oranye";
                this.atap = "Biru";
                this.decorations[0] = "Jemuran";
                break;
            case 4:
                this.tembok = "Abu-abu";
                this.atap = "Oranye";
                this.decorations[0] = "Tanaman";
                this.decorations[1] = "BenderaSmall";
                break;
            default:
                break;
        }
    }
}
