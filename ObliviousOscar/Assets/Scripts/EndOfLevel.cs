public class EndOfLevel : OscarEnterDetecter
{
	protected override void OnOscarEnter ()
	{
		Oscar.Instance.SetIdle (true);
	}
}
