using UnityEngine;

public class Oscar : UnitySingleton<Oscar>
{
	public const string Tag = "Oscar";
	
	public static float Speed = 3f;

	public Sprite finalSprite;

	public Sprite startSprite;

	static bool firstInstance = true;

	public bool IsRunning{ get; set; }

	void Start ()
	{
		IsRunning = true;
		tag = Tag;
		if (firstInstance) {
			firstInstance = false;
		} else {
			transform.position = SavePointsManager.Instance.LatestPosition;
		}
	}

	void Update ()
	{
		if (IsRunning) {
			transform.position += transform.right * Time.deltaTime * Speed;
		}
	}

	public void Kill ()
	{
		#if UNITY_5_3
		UnityEngine.SceneManagement.SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		#else
		Application.LoadLevel (Application.loadedLevel);
		#endif
	}

	public void EndLevel ()
	{
		GetComponent<Animator> ().enabled = false;
		GetComponent<SpriteRenderer> ().sprite = finalSprite;
		IsRunning = false;
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