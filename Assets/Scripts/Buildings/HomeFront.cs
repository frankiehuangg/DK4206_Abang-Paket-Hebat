using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeFront : Building
{
    public override void SetDescription()
    {
        this.view = "Front";

        switch (this.spriteIndex)
        {
            case 0:
                this.tembok = "Pink";
                this.atap = "AbuTerang";
                this.decorations[0] = "Tanaman";
                break;
            case 1:
                this.tembok = "Biru";
                this.atap = "Oranye";
                this.decorations[0] = "Tanaman";
                break;
            case 2:
                this.tembok = "Kuning";
                this.atap = "Biru";
                this.decorations[0] = "Tanaman";
                break;
            case 3:
                this.tembok = "Merah";
                this.atap = "Oranye";
                this.decorations[0] = "Jemuran";
                this.decorations[1] = "Saklar";
                break;
            case 4:
                this.tembok = "Hijau";
                this.atap = "AbuGelap";
                this.decorations[0] = "Tanaman";
                this.decorations[1] = "TorrenOren";
                break;
            case 5:
                this.tembok = "BiruTerang";
                this.atap = "Biru";
                this.decorations[0] = "Tanaman";
                this.decorations[1] = "BenderaSmall";
                break;
            case 6:
                this.tembok = "Coklat";
                this.atap = "Oranye";
                this.decorations[0] = "Tanaman";
                this.decorations[1] = "TorrenOren";
                break;
            default:
                break;
        }
    }
}
