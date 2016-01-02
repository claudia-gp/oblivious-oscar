using UnityEngine;

public class Oscar : UnitySingleton<Oscar>
{
	public const string Tag = "Oscar";
	
	public const float Speed = 3f;

	public Sprite finalSprite;

	public Sprite startSprite;

	public bool IsRunning{ get; set; }

	public bool IsAnimationEnabled {
		get { return animator.enabled; }
		set { animator.enabled = value; }
	}

	public Sprite Sprite {
		get { return spriteRenderer.sprite; }
		set { spriteRenderer.sprite = value; }
	}

	public OscarState State {
		get{ return new OscarState (position: transform.position, direction: Direction, cameraPosition: Camera.main.transform.position); }
		set {
			Direction = value.Direction;
			if (Direction != transform.right) {
				spriteRenderer.flipX = !spriteRenderer.flipX;
			}
			transform.position = value.Position;
			Camera.main.transform.position = value.CameraPosition;
		}
	}

	public Rigidbody2D RigidBody2D{ get; private set; }

	public Vector3 Direction{ get; private set; }

	Animator animator;
	SpriteRenderer spriteRenderer;

	protected new void Awake ()
	{
		base.Awake ();
	
		IsRunning = true;
		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		RigidBody2D = GetComponent<Rigidbody2D> ();

		if (SavePointsManager.HasLatestState) {
			State = SavePointsManager.LatestState;
		} else {
			Direction = transform.right;

			SavePointsManager.InitialState = State;
			SavePointsManager.LatestState = State;
		}
	}

	public void UpdateLatestState ()
	{
		SavePointsManager.LatestState = State;
	}

	public void ResetToInitialState ()
	{
		SavePointsManager.LatestState = SavePointsManager.InitialState;
	}

	public void FlipDirection ()
	{
		Direction *= -1;
		spriteRenderer.flipX = !spriteRenderer.flipX;
	}

	void Update ()
	{
		if (IsRunning) {
			transform.position += Direction * Time.deltaTime * Speed;
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.GetComponent<StopsOscar> ()) {
			IsRunning = false;
		}
	}

	void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.gameObject.GetComponent<StopsOscar> ()) {
			IsRunning = true;
		}
	}

}