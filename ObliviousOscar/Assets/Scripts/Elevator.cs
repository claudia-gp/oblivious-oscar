public class Elevator : OscarEnterExitDetecter
{
    public bool IsOscarIn{ get; private set; }

    protected override void OnOscarEnter()
    {
        IsOscarIn = true;
    }

    protected override void OnOscarExit()
    {
        IsOscarIn = false;
    }
}
