using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Oscar : Singleton<Oscar>
{
	public const string Tag = "Oscar";

	public static float Speed = 3f;

	static bool firstInstance = true;

	void Start ()
	{
		if (firstInstance) {
			firstInstance = false;
		} else {
			transform.position = SavePointsManager.Instance.LatestPosition;
		}
	}

	void Update ()
	{
		transform.position += transform.right * Time.deltaTime * Speed;
	}

	public void Kill ()
	{
		#if UNITY_5_3
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		#else
		Application.LoadLevel (Application.loadedLevel);
		#endif
	}
}