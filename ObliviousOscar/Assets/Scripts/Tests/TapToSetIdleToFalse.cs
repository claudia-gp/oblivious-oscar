public class TapToSetIdleToFalse : Tappable
{
    public override void OnClick()
    {
        Oscar.Instance.SetIdle(false);
    }
}
