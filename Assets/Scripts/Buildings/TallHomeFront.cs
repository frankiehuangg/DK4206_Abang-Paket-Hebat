using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallHomeFront : Building
{
    public override void SetDescription()
    {
        this.view = "Front";

        switch (this.spriteIndex)
        {
            case 0:
                this.tembok = "Abu";
                this.atap = "Oranye";
                this.decorations[0] = "Tanaman";
                this.decorations[1] = "Bel";
                this.decorations[2] = "TorrenBiru";
                break;
            case 1:
                this.tembok = "Oranye";
                this.atap = "AbuGelap";
                this.decorations[0] = "Saklar";
                this.decorations[1] = "Bel";
                break;
            case 2:
                this.tembok = "Kuning";
                this.atap = "AbuTerang";
                this.decorations[0] = "Jemuran";
                this.decorations[1] = "TorrenBiru";
                break;
            default:
                break;
        }
    }
}
