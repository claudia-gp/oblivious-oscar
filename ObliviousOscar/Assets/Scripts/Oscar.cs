using UnityEngine;

public class Oscar : UnitySingleton<Oscar>
{
	float speed;
	const float UphillSpeed = 2f;
	const string AnimIsRunning = "IsRunning";
	public const string AnimIsDead = "IsDead";

	public bool IsRunning { get; set; }

	public bool IsUphill { get; set; }

	public Sprite Sprite {
		get { return spriteRenderer.sprite; }
		set { spriteRenderer.sprite = value; }
	}

	public OscarState State {
		get { return new OscarState (position: transform.position, direction: Direction, cameraPosition: Camera.main.transform.position); }
		set {
			Direction = value.Direction;
			if (Direction != transform.right) {
				spriteRenderer.flipX = !spriteRenderer.flipX;
			}
			transform.position = value.Position;
			Camera.main.transform.position = value.CameraPosition;
		}
	}

	public Rigidbody2D RigidBody2D { get; private set; }

	public Vector3 Direction { get; private set; }

	public Animator Animator{ get; private set; }

	SpriteRenderer spriteRenderer;

	protected new void Awake ()
	{
		base.Awake ();

		IsRunning = true;
		Animator = GetComponent<Animator> ();
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

	void Start ()
	{
		speed = OscarSpeed.Instance.Speed;
	}

	void Update ()
	{
		if (IsRunning) {
			transform.position += Direction * Time.deltaTime * speed;
			if (IsUphill) {
				transform.position += transform.up * Time.deltaTime * UphillSpeed;
			}
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

	public void SetIdle (bool isIdle)
	{
		IsRunning = !isIdle;
		Animator.SetBool (AnimIsRunning, !isIdle);
	}
}
