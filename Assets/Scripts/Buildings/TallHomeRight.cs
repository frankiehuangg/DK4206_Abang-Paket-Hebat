using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallHomeRight : Building
{
    public override void SetDescription()
    {
        this.view = "Right";

        switch (this.spriteIndex)
        {
            case 0:
                this.tembok = "Putih";
                this.atap = "Oranye";
                this.decorations[0] = "Sangkar";
                this.decorations[1] = "Tanaman";
                break;
            case 1:
                this.tembok = "Abu";
                this.atap = "Biru";
                this.decorations[0] = "BenderaSmall";
                this.decorations[1] = "Bel";
                break;
            case 2:
                this.tembok = "Abu";
                this.atap = "AbuGelap";
                this.decorations[0] = "Jemuran";
                this.decorations[1] = "Tanaman";
                break;
            default:
                break;
        }
    }
}
