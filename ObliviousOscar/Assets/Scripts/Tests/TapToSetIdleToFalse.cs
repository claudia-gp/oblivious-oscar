public class TapToSetIdleToFalse : Tappable
{
    public override void OnTap()
    {
        Oscar.Instance.SetIdle(false);
    }
}
