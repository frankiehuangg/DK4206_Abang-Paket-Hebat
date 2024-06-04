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
                this.atap = "AbuGelap";
                this.decorations[0] = "Jemuran";
                this.decorations[1] = "Tanaman";
                break;
            case 1:
                this.tembok = "Hijau";
                this.atap = "AbuGelap";
                this.decorations[0] = "Sangkar";
                break;
            case 2:
                this.tembok = "Putih";
                this.atap = "Oranye";
                this.decorations[0] = "BenderaSmall";
                this.decorations[1] = "Tanaman";
                break;
            case 3:
                this.tembok = "Kuning";
                this.atap = "Oranye";
                this.decorations[0] = "Saklar";
                this.decorations[1] = "Tanaman";
                this.decorations[2] = "TorrenBiru";
                break;
            case 4:
                this.tembok = "Hijau";
                this.atap = "AbuTerang";
                break;
            default:
                break;
        }
    }
}
