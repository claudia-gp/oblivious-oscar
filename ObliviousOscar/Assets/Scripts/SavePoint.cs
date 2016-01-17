public class SavePoint : OscarEnterDetecter
{
	protected override void OnOscarEnter ()
	{
		SoundManager.Instance.Play (SoundManager.Instance.SavePoint);

		Oscar.Instance.UpdateLatestState ();
	}
}
