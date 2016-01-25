public class ReverseDirection : OscarEnterDetecter
{
    protected override void OnOscarEnter()
    {
        OscarController.Instance.ReverseDirection();
    }
}
