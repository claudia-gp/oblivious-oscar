using UnityEngine;

public class Oscar : UnitySingleton<Oscar>
{
	public const string Tag = "Oscar";
	
	public static float Speed = 3f;

	public Sprite finalSprite;

	static bool firstInstance = true;

	bool isRunning = true;

	void Start ()
	{
		tag = Tag;
		if (firstInstance) {
			firstInstance = false;
		} else {
			transform.position = SavePointsManager.Instance.LatestPosition;
		}
	}

	void Update ()
	{
		if (isRunning) {
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
		isRunning = false;
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.GetComponent<StopsOscar> ()) {
			isRunning = false;
		}
	}

	void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.gameObject.GetComponent<StopsOscar> ()) {
			isRunning = true;
		}
	}
}