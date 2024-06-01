using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class ZoomOut : PowerUp
{
    protected override void getCount() {
        count = PowerUpManager.instance.zoomOut;
    }

    public override void Activate() {
        PowerUpManager.instance.ActivateZoomOut();
    }
}