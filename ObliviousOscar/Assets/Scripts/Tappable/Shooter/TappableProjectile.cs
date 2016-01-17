
public class TappableProjectile : Tappable
{
    public override void OnTap()
    {
        Destroy(gameObject);
    }

    public void OnDrag()
    {
        OnTap();
    }
}
