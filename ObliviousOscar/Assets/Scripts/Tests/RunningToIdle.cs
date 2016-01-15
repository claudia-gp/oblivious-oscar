public class RunningToIdle : OscarEnterDetecter
{
    protected override void OnOscarEnter()
    {
        Oscar.Instance.SetIdle(true);
        Destroy(gameObject);
    }
}
