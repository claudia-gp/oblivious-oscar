public class StopsOscar : OscarEnterExitDetecter
{
    protected override void OnOscarEnter()
    {
        Oscar.Instance.IsRunning = false;
    }

    protected override void OnOscarExit()
    {
        Oscar.Instance.IsRunning = true;
    }
}
