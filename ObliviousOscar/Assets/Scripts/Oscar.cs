using UnityEngine;

public class Oscar : UnitySingleton<Oscar>
{
	public const string Tag = "Oscar";
	
	public const float Speed = 3f;

	public Sprite finalSprite;

	public Sprite startSprite;

	public bool IsRunning{ get; set; }

	public bool IsAnimationEnabled {
		get {
			return animator.enabled;
		}
		set {
			animator.enabled = value;
		}
	}

	public Sprite Sprite { 
		get {
			return spriteRenderer.sprite;
		}
		set {
			spriteRenderer.sprite = value;
		}
	}

	Animator animator;
	SpriteRenderer spriteRenderer;

	protected new void Awake ()
	{
		base.Awake ();

		IsRunning = true;

		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();

		if (SavePointsManager.HasLatestPosition) {
			transform.position = SavePointsManager.LatestPosition;
		} else {
			SavePointsManager.InitialPosition = transform.position;
			SavePointsManager.LatestPosition = transform.position;
		}
	}

	public void UpdateLatestPosition ()
	{
		SavePointsManager.LatestPosition = transform.position;
	}

	public void ResetToInitialPosition ()
	{
		SavePointsManager.LatestPosition = SavePointsManager.InitialPosition;
	}

	void Update ()
	{
		if (IsRunning) {
			transform.position += transform.right * Time.deltaTime * Speed;
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