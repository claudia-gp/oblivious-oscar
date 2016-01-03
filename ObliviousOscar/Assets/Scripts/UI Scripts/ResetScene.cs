
public class ResetScene : RetryLevelInteraction
{
	public override void Send ()
	{
		
		LevelManager.ResetLevel ();
		base.Send ();
	}
}
