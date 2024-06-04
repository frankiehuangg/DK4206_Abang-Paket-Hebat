public class ZoomOut : PowerUp
{
    protected override void getCount()
    {
        count = PowerUpManager.instance.zoomOut;
    }

    public override void Activate()
    {
        PowerUpManager.instance.ActivateZoomOut();
    }
}