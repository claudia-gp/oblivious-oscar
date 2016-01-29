public class OscarSpeed : PersistentSingleton<OscarSpeed>
{
	public const float Slow = 2f;
	public const float Medium = 3f;
	public const float Fast = 4f;

	float _speed = Medium;

	public float Speed {
		get{ return _speed; }
		set{ _speed = value; }
	}

	protected new void Awake ()
	{
		base.Awake ();

		Speed = Medium;
	}
}
