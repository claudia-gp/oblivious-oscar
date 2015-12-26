using UnityEngine;
using System.Collections;

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

	//TODO try to make Oscar persistent
	static Hashtable latestPositions = new Hashtable ();
	static Hashtable initialPositions = new Hashtable ();

	Animator animator;
	SpriteRenderer spriteRenderer;

	protected new void Awake ()
	{
		base.Awake ();
		IsRunning = true;
		tag = Tag;

		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();

		if (latestPositions.ContainsKey (Application.loadedLevel)) {
			transform.position = (Vector3)latestPositions [Application.loadedLevel];
		} else {
			initialPositions [Application.loadedLevel] = transform.position;
			latestPositions [Application.loadedLevel] = transform.position;
		}
	}

	public void UpdateLatestPosition ()
	{
		latestPositions [Application.loadedLevel] = transform.position;
	}

	public void ResetToInitialPosition ()
	{
		latestPositions [Application.loadedLevel] = initialPositions [Application.loadedLevel];
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