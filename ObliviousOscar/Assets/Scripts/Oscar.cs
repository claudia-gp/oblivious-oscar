using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Oscar : Singleton<Oscar>
{
	public const string Tag = "Oscar";

	public static readonly Vector3 InitialPosition = new Vector3 (-6.5f, 0f);

	public static float Speed = 3f;

	void Start ()
	{
		transform.position = SavePointsManager.Instance.LatestPosition;
	}

	void Update ()
	{
		transform.position += transform.right * Time.deltaTime * Speed;
	}

	public void Kill ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}