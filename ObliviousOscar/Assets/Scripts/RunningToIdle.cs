public class RunningToIdle : OscarEnterDetecter
{
    protected override void OnOscarEnter()
    {
        Oscar.Instance.Idle();
        Destroy(gameObject);
    }
}
