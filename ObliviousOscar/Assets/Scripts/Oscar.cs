using UnityEngine;
using System.Collections;

public class Oscar : MonoBehaviour
{
	public const string Tag = "Oscar";

	public static float Speed = 3f;
	
	private static Vector3 previousPosition;

	private static int instanceCount = 0;

	public static Oscar Instance {
		get;
		private set;
	}

	public static Vector3 DeltaPosition {
		get{ return Instance ? Instance.transform.position - previousPosition : new Vector3 (); }
	}

	void Awake ()
	{
		if (instanceCount == 0) {
			Instance = this;
			instanceCount++;
		} else {
			Destroy (gameObject);
		}
	}

	void Update ()
	{
		transform.position += transform.right * Time.deltaTime * Speed;
	}

	void LateUpdate ()
	{
		previousPosition = transform.position;
	}

	public void Kill ()
	{
		Camera.main.transform.parent = null;
		Destroy (gameObject);
	}
}
