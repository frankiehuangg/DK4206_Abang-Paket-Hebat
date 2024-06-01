using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class SpeedUp : PowerUp
{
    protected override void getCount() {
        count = PowerUpManager.instance.speedUp;
    }

    public override void Activate() {
        PowerUpManager.instance.ActivateSpeedUp();
    }
}