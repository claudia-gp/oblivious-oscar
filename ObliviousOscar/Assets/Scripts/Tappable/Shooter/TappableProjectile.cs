
public class TappableProjectile : Tappable
{
    public override void OnClick()
    {
        Destroy(gameObject);
    }

    public void OnDrag()
    {
        OnClick();
    }
}
