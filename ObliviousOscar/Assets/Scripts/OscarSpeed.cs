public class OscarSpeed : PersistentSingleton<OscarSpeed>
{
	public const float Slow = 2f;
	public const float Medium = 3f;
	public const float Fast = 4f;

	public float Speed{ get; set; }

	protected new void Awake ()
	{
		base.Awake ();

		Speed = Medium;
	}
}
