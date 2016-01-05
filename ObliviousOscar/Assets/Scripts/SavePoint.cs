public class SavePoint : OscarEnterDetecter
{
    protected override void OnOscarEnter()
    {
        Oscar.Instance.UpdateLatestState();
    }
}
