using System;

public class KillingObject : OscarEnterDetecter
{
	static DateTime lastTime;
	static readonly TimeSpan MinTimeBetweenKills = new TimeSpan (0, 0, 0, 0, 500);

	protected override void OnOscarEnter ()
	{
		if (DateTime.Now - lastTime > MinTimeBetweenKills) {
			lastTime = DateTime.Now;
			OscarController.Instance.Kill ();
		}
	}
}