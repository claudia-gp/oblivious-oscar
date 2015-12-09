using UnityEngine;
using System.Collections;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	protected Singleton ()
	{
	}

	public static T Instance { get; private set; }

	protected void Awake ()
	{
		if (Instance == null) {
			Instance = GetComponent<T> ();
		} else {
			DestroyImmediate (gameObject);
		}
	}

}
