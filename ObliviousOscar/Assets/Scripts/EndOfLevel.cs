public class EndOfLevel : OscarEnterDetecter
{
    protected override void OnOscarEnter()
    {
        OscarController.Instance.StopOscarAndSayHi();
    }
}
