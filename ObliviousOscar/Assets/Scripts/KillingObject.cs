public class KillingObject : OscarEnterDetecter
{
    protected override void OnOscarEnter()
    {
        OscarController.Instance.Kill();
    }
}