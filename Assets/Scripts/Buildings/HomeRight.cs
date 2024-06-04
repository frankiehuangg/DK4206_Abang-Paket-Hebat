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
                this.decorations[0] = "Tanaman";
                break;
            case 1:
                this.tembok = "Putih";
                this.atap = "Biru";
                this.decorations[0] = "BenderaSmall";
                this.decorations[1] = "Saklar";
                break;
            case 2:
                this.tembok = "BiruTerang";
                this.atap = "Oranye";
                this.decorations[0] = "Tanaman";
                break;
            case 3:
                this.tembok = "Hijau";
                this.atap = "Oranye";
                this.decorations[0] = "Jemuran";
                break;
            case 4:
                this.tembok = "Biru";
                this.atap = "Oranye";
                this.decorations[0] = "Jemuran";
                this.decorations[1] = "Tanaman";
                break;
            case 5:
                this.tembok = "Putih";
                this.atap = "AbuGelap";
                this.decorations[0] = "Tanaman";
                this.decorations[1] = "TorrenOren";
                break;
            case 6:
                this.tembok = "Kuning";
                this.atap = "AbuGelap";
                this.decorations[0] = "Tanaman";
                this.decorations[1] = "BenderaSmall";
                break;
            default:
                break;
        }
    }
}
