public class SpeedUp : PowerUp
{
    protected override void getCount()
    {
        count = PowerUpManager.instance.speedUp;
    }

    public override void Activate()
    {
        PowerUpManager.instance.ActivateSpeedUp();
    }
}