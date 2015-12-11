using UnityEngine;
using System.Collections;

public class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
{
	protected new void Awake ()
	{
		base.Awake ();
		Instance.gameObject.transform.SetParent (null);
		DontDestroyOnLoad (Instance.gameObject);
	}
}
