public class SavePoint : OscarEnterDetecter
{
	bool wasActivated;

	protected override void OnOscarEnter ()
	{
		if (!wasActivated) {
			wasActivated = true;
			SoundManager.Instance.Play (SoundManager.Instance.SavePoint);
		}

		Oscar.Instance.UpdateLatestState ();
	}
}
